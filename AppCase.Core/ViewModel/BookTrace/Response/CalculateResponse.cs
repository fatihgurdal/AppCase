using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Core.ViewModel.BookTrace.Response
{
    public class CalculateResponse
    {
        /// <summary>
        /// Ceza tutarı - parabirimi ve detaylı hesap için decimal kullanılıyor
        /// </summary>
        public decimal PenaltyAmount { get; set; }
        public string PenaltyAmountStr { get; set; }
    }
}
