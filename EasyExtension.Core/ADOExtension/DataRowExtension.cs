using System;
using System.Data;

namespace EasyExtension.Data
{
    /// <summary>
    /// Extension for DataRow
    /// For example:
    /// ----------------------------
    /// DataRow dr=xxxxx;
    /// dr.ToInt32("ColumnName",-1);
    /// ----------------------------
    /// powerd by cn-whm 2021.1.28
    /// ----------------------------
    /// </summary>
    public static class DataRowExtension
    {
        /// <summary>
        /// Convert cell value to int32
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="columnName">we will use dataRow[0] instead of empty columnName</param>
        /// <param name="defaultVal">the value should return if convert is failed or your data row value is DBNull</param>
        /// <returns></returns>
        public static int ToInt32(this DataRow dataRow, string columnName, int defaultVal = 0)
        {
            if (dataRow == null)
                throw new ArgumentNullException("dataRow");
            int result = defaultVal;
            if (!string.IsNullOrEmpty(columnName))
            {
                result = GlobalExt.ObjectToInt32(dataRow[columnName], defaultVal);
            }
            else
            {
                result = GlobalExt.ObjectToInt32(dataRow[0], defaultVal);
            }
            return result;
        }
        /// <summary>
        /// Convert cell value to uInt16
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="columnName">we will use dataRow[0] instead of empty columnName</param>
        /// <param name="defaultVal">the value should return if convert is failed or your data row value is DBNull</param>
        /// <returns></returns>
        public static ushort ToUInt16(this DataRow dataRow, string columnName, ushort defaultVal = 0)
        {
            if (dataRow == null)
                throw new ArgumentNullException("dataRow");
            ushort result = defaultVal;
            if (!string.IsNullOrEmpty(columnName))
            {
                result = GlobalExt.ObjectToUshort(dataRow[columnName], defaultVal);
            }
            else
            {
                result = GlobalExt.ObjectToUshort(dataRow[0], defaultVal);
            }
            return result;
        }
        /// <summary>
        /// Convert cell value to bool
        /// </summary>
        /// <param name="dataRow">data row value could be: "True","true","False","false",0,1,or any other numbers</param>
        /// <param name="columnName">we will use dataRow[0] instead of empty columnName</param>
        /// <param name="defaultVal">the value should return if convert is failed or your data row value is DBNull</param>
        /// <returns>return ture if data row value is numberic and greater than 0,otherwise return false</returns>
        public static bool ToBoolean(this DataRow dataRow, string columnName, bool defaultVal = false)
        {
            if (dataRow == null)
                throw new ArgumentNullException("dataRow");
            bool result = defaultVal;
            if (!string.IsNullOrEmpty(columnName))
            {
                return GlobalExt.ObjectToBoolean(dataRow[columnName]);
            }
            else
            {
                return GlobalExt.ObjectToBoolean(dataRow[0]);
            }
        }
        /// <summary>
        /// Convert cell value to DateTime
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="columnName">we will use dataRow[0] instead of empty columnName</param>
        /// <param name="defaultVal">the value should return if convert is failed or your data row value is DBNull</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this DataRow dataRow, string columnName, DateTimeDefaultReturn defaultDtVal = DateTimeDefaultReturn.Now)
        {
            if (dataRow == null)
                throw new ArgumentNullException("dataRow");

            if (!string.IsNullOrEmpty(columnName) && !Convert.IsDBNull(dataRow[columnName]))
            {
                return Convert.ToDateTime(dataRow[columnName]);
            }

            DateTime dtNow = DateTime.Now;
            if (defaultDtVal == DateTimeDefaultReturn.Min)
                dtNow = DateTime.MinValue;
            if (defaultDtVal == DateTimeDefaultReturn.Max)
                dtNow = DateTime.MaxValue;

            return dtNow;
        }

        /// <summary>
        /// Convert cell value to DateTime
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="columnName"></param>
        /// <returns>Default is null</returns>
        public static DateTime? ToDateTimeNullable(this DataRow dataRow, string columnName)
        {
            if (dataRow == null)
                throw new ArgumentNullException("dataRow");

            if (!string.IsNullOrEmpty(columnName) && !Convert.IsDBNull(dataRow[columnName]))
            {
                return Convert.ToDateTime(dataRow[columnName]);
            }

            return null;
        }

        /// <summary>
        /// Convert cell value to DateTime string
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="columnName">we will use dataRow[0] instead of empty columnName</param>
        /// <param name="defaultVal">the value should return if convert is failed or your data row value is DBNull</param>
        /// <returns></returns>
        public static string ToDateTimeString(this DataRow dataRow, string columnName, DateTimeDefaultReturn defaultDtVal = DateTimeDefaultReturn.Now, string format = "yyyy-MM-dd HH:mm:ss")
        {
            if (dataRow == null)
                throw new ArgumentNullException("dataRow");
            DateTime dtNow;

            if (!string.IsNullOrEmpty(columnName) && !Convert.IsDBNull(dataRow[columnName]))
            {
                dtNow = Convert.ToDateTime(dataRow[columnName]);
            }
            else
            {
                switch (defaultDtVal)
                {
                    case DateTimeDefaultReturn.Min:
                        dtNow = DateTime.MinValue;
                        break;
                    case DateTimeDefaultReturn.Max:
                        dtNow = DateTime.MaxValue;
                        break;
                    default:
                        dtNow = DateTime.Now;
                        break;
                }
            }

            return dtNow.ToString(format);
        }

        /// <summary>
        /// Convert cell value to  string
        /// </summary>
        /// <param name="dataRow"></param>
        /// <param name="columnName">we will use dataRow[0] instead of empty columnName</param>
        /// <param name="defaultVal">the value should return if convert is failed or your data row value is DBNull</param>
        /// <returns></returns>
        public static string ToString(this DataRow dataRow, string columnName, string defaultVal = "")
        {
            if (dataRow == null)
                throw new ArgumentNullException("dataRow");
            string result = defaultVal;
            if (!string.IsNullOrEmpty(columnName))
            {
                result = GlobalExt.ObjectToString(dataRow[columnName]);
            }
            else
            {
                result = GlobalExt.ObjectToString(dataRow[0]);
            }
            return result;
        }

        public static decimal ToDecimal(this DataRow dataRow, string columnName, decimal defaultVal = 0)
        {
            if (dataRow == null)
                throw new ArgumentNullException("dataRow");
            decimal result = defaultVal;
            if (!string.IsNullOrEmpty(columnName))
            {
                result = GlobalExt.ObjectToDecimal(dataRow[columnName]);
            }
            else
            {
                result = GlobalExt.ObjectToDecimal(dataRow[0]);
            }
            return result;
        }

        public static double ToDouble(this DataRow dataRow, string columnName, double defaultVal = 0)
        {
            if (dataRow == null)
                throw new ArgumentNullException("dataRow");
            double result = defaultVal;
            if (!string.IsNullOrEmpty(columnName))
            {
                result = GlobalExt.ObjectToDouble(dataRow[columnName]);
            }
            else
            {
                result = GlobalExt.ObjectToDouble(dataRow[0]);
            }
            return result;
        }

        public static float ToFloat(this DataRow dataRow, string columnName, float defaultVal = 0)
        {
            if (dataRow == null)
                throw new ArgumentNullException("dataRow");
            float result = defaultVal;
            if (!string.IsNullOrEmpty(columnName))
            {
                result = GlobalExt.ObjectToFloat(dataRow[columnName]);
            }
            else
            {
                result = GlobalExt.ObjectToFloat(dataRow[0]);
            }
            return result;
        }
    }
}
