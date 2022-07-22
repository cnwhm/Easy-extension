using System;
using System.Collections.Generic;
using System.Text;

namespace EasyExtension
{
    internal class GlobalExt
    {
        public static bool ObjectToBoolean(object val, bool defaultValue = false)
        {
            if (Convert.IsDBNull(val) || null == val)
                return defaultValue;
            string cellValue = val.ToString().ToLower();
            if (!string.IsNullOrEmpty(cellValue))
            {
                int parseValue = 0;
                if (int.TryParse(cellValue, out parseValue))
                {
                    return parseValue > 0;
                }
                else if("true".Equals(cellValue))
                {
                    return true;
                }
            }
            return false;
        }

        public static string ObjectToString(object val, string defaultValue = "")
        {
            if (Convert.IsDBNull(val) || val == null)
                return defaultValue;
            return val.ToString();
        }

        public static int ObjectToInt32(object val, int defaultVal = 0)
        {
            if (Convert.IsDBNull(val) || val == null)
                return defaultVal;
            return Convert.ToInt32(val);
        }

        public static ushort ObjectToUshort(object val, ushort defaultVal = 0)
        {
            if (Convert.IsDBNull(val) || val == null)
                return defaultVal;
            return Convert.ToUInt16(val);
        }

        public static decimal ObjectToDecimal(object val, decimal defaultVal = 0)
        {
            if (Convert.IsDBNull(val) || val == null)
                return defaultVal;
            return Convert.ToDecimal(val);
        }
    }
    public enum DateTimeDefaultReturn
    {
        Min, Max, Now
    }
}
