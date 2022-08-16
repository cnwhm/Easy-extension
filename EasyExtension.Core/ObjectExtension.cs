﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyExtension
{
    public static class ObjectExtension
    {
        /// <summary>
        /// 将 DateTimeOffset 转换成本地 DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(this DateTimeOffset dateTime)
        {
            if (dateTime.Offset.Equals(TimeSpan.Zero))
                return dateTime.UtcDateTime;

            if (dateTime.Offset.Equals(TimeZoneInfo.Local.GetUtcOffset(dateTime.DateTime)))
                return dateTime.ToLocalTime().DateTime;
            else
                return dateTime.DateTime;
        }

        /// <summary>
        /// 将 DateTimeOffset? 转换成本地 DateTime?
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime? ConvertToDateTime(this DateTimeOffset? dateTime)
        {
            if (dateTime == null) return null;

            return dateTime.Value.ConvertToDateTime();
        }

        /// <summary>
        /// 将 DateTime 转换成 DateTimeOffset
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTimeOffset ConvertToDateTimeOffset(this DateTime dateTime)
        {
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
        }

        /// <summary>
        /// 将 DateTime? 转换成 DateTimeOffset?
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTimeOffset? ConvertToDateTimeOffset(this DateTime? dateTime)
        {
            if (dateTime == null) return null;

            return dateTime.Value.ConvertToDateTimeOffset();
        }
    }
}
