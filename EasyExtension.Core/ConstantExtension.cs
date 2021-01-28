using System;
using System.Collections.Generic;
using System.Text;

namespace EasyExtension
{
    public static class ConstantExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="defaultFormat"></param>
        /// <returns>2021-01-28 00:00:00</returns>
        public static string FormatBeginDate(this string date,string defaultFormat= "yyyy-MM-dd HH:mm:ss")
        {
            return Convert.ToDateTime(date).Date.ToString(defaultFormat);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="defaultFormat"></param>
        /// <returns>2021-01-28 23:59:59</returns>
        public static string FormatEndDate(this string date, string defaultFormat = "yyyy-MM-dd HH:mm:ss")
        {
            if (date.Length < 11)
            {
                return Convert.ToDateTime(date).Date.AddDays(1).AddMilliseconds(-1).ToString(defaultFormat);
            }
            else
            {
                return FormatBeginDate(date);
            }
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="param"> </param>
        /// <param name="defaultVal"> </param>
        /// <returns></returns>
        public static int ToInt32(this string param, int defaultVal = 0)
        {
            int result = defaultVal;
            if (!int.TryParse(param, out result))
            {
                return defaultVal;
            }
            return result;
        }
        public static ushort ToUShort(this string param, ushort defaultVal = 0)
        {
            ushort result = defaultVal;
            if (!ushort.TryParse(param, out result))
            {
                return defaultVal;
            }
            return result;
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="param"></param>
        /// <returns>"0" or "false" or empty string return false  ,otherwise return true. maybe return true if ur param is any word</returns>
        public static bool ToBoolean(this string param)
        {
            if (string.IsNullOrEmpty(param))
                return false;
            string strlowercase = param.Trim().ToLower();
            if (strlowercase == "true")
                return true;
            else if (strlowercase == "false")
                return false;
            else
                return param == "0" ? false : true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static bool ToBoolean(this int param)
        {
            return param > 0;
        }
        public static ushort ToUshort(this int _val)
        {
            return Convert.ToUInt16(_val);
        }

        public static int ToInt32(this bool _val)
        {
            return _val ? 1 : 0;
        }
    }
}
