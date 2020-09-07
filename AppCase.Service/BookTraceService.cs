using AppCase.Core.Enum;
using AppCase.Core.Exception;
using AppCase.Core.Helper;
using AppCase.Core.Repository;
using AppCase.Core.Services;
using AppCase.Core.ViewModel.BookTrace.Request;
using AppCase.Core.ViewModel.BookTrace.Response;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AppCase.Service
{
    public class BookTraceService : IBookTraceService
    {
        public BookTraceService(IBookTraceRepository bookTraceRepository, ICountryHolidayRepository countryHolidayRepository, ICountryRepository countryRepository)
        {
            BookTraceRepository = bookTraceRepository;
            CountryHolidayRepository = countryHolidayRepository;
            CountryRepository = countryRepository;
        }

        public IBookTraceRepository BookTraceRepository { get; }
        public ICountryHolidayRepository CountryHolidayRepository { get; }
        public ICountryRepository CountryRepository { get; }

        public CalculateResponse Calculate(CalculateRequest request)
        {
            var country = CountryRepository.Get(x => x.Culture == request.CountryCulture);

            if (country == null)
            {
                throw new NotFoundExcepiton("Ülke bulunamadı");
            }

            if (request.BookReturnDate < request.BookCheckoutDate)
            {
                throw new BadRequestException("İade tarihi ödünç tarihinden küçük olamaz");
            }

            var holidays = CountryHolidayRepository.Where(x => x.CountryId == country.Id).ToList();


            #region Resmi ve Dini tatiller
            var noRepeatHolidays = holidays.Where(x => x.HolidayType == Core.Enum.HolidayType.NoRepeat).Select(x => x.Holiday).ToList();
            var RepeatHolidays = holidays.Where(x => x.HolidayType == Core.Enum.HolidayType.Repeat).Select(x => x.Holiday).ToList();
            #endregion

            //gün listesi çıkarıldı
            var days = CommonHelper.RangeList(request.BookCheckoutDate, request.BookReturnDate);

            if (days.Count > 10)
            {
                #region İlk 10 gün düşürüldü

                days.RemoveRange(0, 10); //İlk 10 günden sonraki işgünleri hesap edildiğini anladım. Yani ilk 10 gün tatil günlerine bakılmayacak 10'günden sonra iş günleri için ceza uygulanacak
                #endregion

                #region Tekrar etmeyen tatilleri düşürüldü
                //Tekrar etmeyen resmi tatiller örneğin her yıl değişen dini bayramlar

                days.RemoveAll(x => noRepeatHolidays.Contains(x)); // tatil gününe denk gelen tekrar etmeyen temizle 
                #endregion

                #region Her yıl tekrar eden tatiller düşürüldü
                //Tekrar eden günler temizlenir. Belirtilen tekrar eden tatil günü yılı başlangıç olarka kabul edilir  ve sonraki yılları kapsar
                foreach (var item in RepeatHolidays)
                {
                    days.RemoveAll(x => x.Day == item.Day && x.Month == item.Month && x.Year >= item.Year);
                }
                #endregion

                #region Haftasonları düşürüldü
                //Haftasonalrını kaldır
                var weekends = country.Weekends.Split(',').Select(x => Enum.Parse<AppCaseDayOfWeek>(x));

                days.RemoveAll(x => weekends.Contains(CommonHelper.GetDayOfWeek(x)));
                #endregion

                //Aralık ile günler üzerinden temizlenir. Çünkü hem hafta sonu hemde resmi tatil günleri kesişirse 2 kez düşmemesi için bu şekilde hesaplanmıştır.

                var calculated = ((decimal)days.Count * 5.00M);
                return new CalculateResponse()
                {
                    PenaltyAmount = calculated,
                    PenaltyAmountStr = calculated.ToString("C0", new CultureInfo(country.Culture))
                };
            }
            else
            {
                return new CalculateResponse()
                {
                    PenaltyAmount = 0,
                    PenaltyAmountStr = 0.ToString("C0", new CultureInfo(country.Culture))
                };
            }
        }

        public CalculateResponse CalculateAndSave(CalculateRequest request)
        {
            var result = Calculate(request);
            var country = CountryRepository.Get(x => x.Culture == request.CountryCulture);
            BookTraceRepository.Add(new Core.Entities.BookTrace()
            {
                BookCheckoutDate = request.BookCheckoutDate,
                BookReturnDate = request.BookReturnDate,
                Calculated = result.PenaltyAmount,
                CountryId = country.Id,
            });

            return result;
        }
    }
}
