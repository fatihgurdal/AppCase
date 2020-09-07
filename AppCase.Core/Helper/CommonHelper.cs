using AppCase.Core.Enum;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCase.Core.Helper
{
    public static class CommonHelper
    {
        public static AppCaseDayOfWeek GetDayOfWeek(DateTime date)
        {
            int year = date.Year; int month = date.Month; int day = date.Day;
            byte[] monthTable = { 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };

            year -= (int)((month < 3) ? 1 : 0);

            return (AppCaseDayOfWeek)((year + year / 4 - year / 100 + year / 400 + monthTable[month - 1] + day) % 7);
        }
        public static List<DateTime> RangeList(this DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (endDate - startDate).Days + 1).Select(d => startDate.AddDays(d)).ToList();
        }
    }
}
