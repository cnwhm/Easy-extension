using System;
using System.Collections.Generic;
using System.Text;

namespace EasyExtension
{
    public static class DateTimeExtension
    {
        public static string ToBeginDate(this DateTime date, string defaultFormat = "yyyy-MM-dd HH:mm:ss")
        {
            return date.Date.ToString(defaultFormat);
        }
        public static string ToEndDate(this DateTime date, string defaultFormat = "yyyy-MM-dd HH:mm:ss")
        {
            return date.Date.AddDays(1).AddMilliseconds(-1).ToString(defaultFormat);
        }
    }
}
