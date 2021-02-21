using System;

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
        public static DateTime FormatBeginDate(this DateTime date)
        {
            return date.Date;
        }
        public static DateTime FormatEndDate(this DateTime date)
        {
            return date.Date.AddDays(1).AddMilliseconds(-1);
        }
    }
}
