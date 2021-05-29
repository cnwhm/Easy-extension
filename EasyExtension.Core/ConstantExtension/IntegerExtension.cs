using System;

namespace EasyExtension
{
    public static class IntegerExtension
    { 
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

    }
}
