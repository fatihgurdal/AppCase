using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Core.ViewModel.BookTrace.Request
{
    public class CalculateRequest
    {
        public DateTime BookCheckoutDate { get; set; }
        public DateTime BookReturnDate { get; set; }
        public string CountryCulture { get; set; }
    }
}
