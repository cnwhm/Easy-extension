using System;

namespace EasyExtension
{
    public static class IntegerExtension
    { 
        /// <summary>
        /// return true while param is greater than 0
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static bool ToBoolean(this int param)
        {
            return param > 0;
        }
        /// <summary>
        /// return UInt16 result, if param <0 then return 0
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static ushort ToUshort(this int param)
        {
            if (param < 0)
                return 0;
            return Convert.ToUInt16(param);
        }
        /// <summary>
        /// return ToInt16 result
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static short ToShort(this int param)
        {
            return Convert.ToInt16(param);
        }
        /// <summary>
        /// return float
        /// </summary>
        /// <param name="_val"></param>
        /// <returns></returns>
        public static float ToFloat(this int param)
        {
            return Convert.ToSingle(param);
        }
        /// <summary>
        /// return double
        /// </summary>
        /// <param name="_val"></param>
        /// <returns></returns>
        public static double ToDouble(this int param)
        {
            return Convert.ToDouble(param);
        }
        /// <summary>
        /// return double
        /// </summary>
        /// <param name="_val"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this int param)
        {
            return Convert.ToDecimal(param);
        }
    }
}
