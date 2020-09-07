using AppCase.Core.ViewModel.BookTrace.Request;
using AppCase.Core.ViewModel.BookTrace.Response;

using System;
using System.Collections.Generic;
using System.Text;

namespace AppCase.Core.Services
{
    public interface IBookTraceService
    {
        /// <summary>
        /// alış ve teslim tarihleri arasında uygun hesaplamayı yapar ve ödenmesi gereken ceza hesapanır
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CalculateResponse Calculate(CalculateRequest request);
    }
}
