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
         
    }
}
