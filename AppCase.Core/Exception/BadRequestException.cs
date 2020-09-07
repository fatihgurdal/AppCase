using AppCase.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Core.Exception
{
    public class BadRequestException : BaseExcepiton
    {
        public BadRequestException(string message) : base(message, string.Empty)
        {

        }
        public BadRequestException(string message, string detail) : base(message, detail)
        {
        }
        public BadRequestException(string message, string detail, ErrorType type) : base(message, detail, type)
        {
        }
    }
}
