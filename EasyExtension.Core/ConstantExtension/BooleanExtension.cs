using System;
using System.Collections.Generic;
using System.Text;

namespace EasyExtension
{
    public static class BooleanExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_val"></param>
        /// <returns>return 1 if value is true .any else 0</returns>
        public static int ToInt32(this bool _val)
        {
            return _val ? 1 : 0;
        }
        public static short ToInt16(this bool _val)
        {
            return _val ? (short)1 : (short)0;
        }
        public static ushort ToUInt16(this bool _val)
        {
            return _val ? (ushort)1 : (ushort)0;
        }
    }
}
