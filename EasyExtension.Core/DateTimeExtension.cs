using System;

namespace EasyExtension
{
    public static class DateTimeExtension
    {
        public static string FormatBeginDate(this DateTime date, string defaultFormat = "yyyy-MM-dd HH:mm:ss")
        {
            return date.Date.ToString(defaultFormat);
        }
        public static string FormatEndDate(this DateTime date, string defaultFormat = "yyyy-MM-dd HH:mm:ss")
        {
            return date.Date.AddDays(1).AddMilliseconds(-1).ToString(defaultFormat);
        }
        public static DateTime ToBeginDate (this DateTime date)
        {
            return date.Date;
        }
        public static DateTime ToEndDate (this DateTime date)
        {
            return date.Date.AddDays(1).AddMilliseconds(-1);
        }
    }
}
