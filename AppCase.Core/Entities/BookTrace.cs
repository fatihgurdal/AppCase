using AppCase.Core.Entities.Abstract;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Core.Entities
{
    public class BookTrace : GuidEntity
    {
        public DateTime BookCheckoutDate { get; set; }
        public DateTime? BookReturnDate { get; set; }
        public long CountryId { get; set; }
        public decimal? Calculated { get; set; }

        //Join
        public Country Country { get; set; }
    }
}
