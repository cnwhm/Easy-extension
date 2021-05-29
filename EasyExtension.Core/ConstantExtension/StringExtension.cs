using System;
using System.Collections.Generic;
using System.Text;

namespace EasyExtension
{
    public static class StringExtension
    {
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
        /// return paresed result if convert sucessed
        /// </summary>
        /// <param name="param"></param>
        /// <param name="defaultReturn">0=DateTime.Now 1=DateTime.MinValue  2=DateTime.MaxValue</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string param,byte defaultReturn=0)
        {
            DateTime result;
            if(DateTime.TryParse(param,out result))
            {
                return result;
            }
            else
            {
                switch (defaultReturn)
                {
                    default:
                    case 0:
                        return DateTime.Now;
                    case 1:
                        return DateTime.MinValue;
                    case 2:
                        return DateTime.MaxValue;
                }
            }
        }
    }
}
