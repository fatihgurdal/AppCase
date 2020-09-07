using AppCase.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Core.Exception
{
    public class ExceptionModel
    {
        public string Message { get; set; }
        public string Detail { get; set; }
        public ErrorType Type { get; set; }
    }
}
