using AppCase.Core.Entities.Abstract;
using AppCase.Core.Enum;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Core.Entities
{
    public class CountryHoliday : GuidEntity
    {
        public Guid CountryId { get; set; }
        public DateTime Holiday { get; set; }
        public HolidayType HolidayType { get; set; }
        //Join
        public Country Country { get; set; }
    }
}
