using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyExtension
{
    public static class DateTimeExtension
    {
        public static string FormatBeginDate(this DateTime date, string defaultFormat = "yyyy-MM-dd HH:mm:ss")
        {
            return date.Date.ToString(defaultFormat);
        }
        public static string FormatEndDate(this DateTime date, string defaultFormat = "yyyy-MM-dd HH:mm:ss")
        {
            return date.Date.AddDays(1).AddMilliseconds(-1).ToString(defaultFormat);
        }
        public static DateTime ToBeginDate(this DateTime date)
        {
            return date.Date;
        }
        public static DateTime ToEndDate(this DateTime date)
        {
            return date.Date.AddDays(1).AddMilliseconds(-1);
        }

        public static IEnumerable<DateTimeRange> MergeDateTime(this IEnumerable<DateTimeRange> dateTimeList)
        {
            if (!dateTimeList.Any())
            {
                return null;
            }

            dateTimeList = dateTimeList.OrderBy(x => x.StartDateTime);
            var rangeList=dateTimeList.ToArray();

            if (rangeList.Length == 1)
            {
                return dateTimeList;
            }

            var result = new List<DateTimeRange>();

            DateTimeRange previous = rangeList[0];
            DateTimeRange next = rangeList[1];
            for (int i = 0; i < rangeList.Length; i++)
            {
                var j = i + 2;
                //没有next了
                if (j > rangeList.Length - 1)
                {
                    result.Add(previous);
                    break;
                }

                var mergedList = GetMergedRange(previous, next);
                //合并完变成一个，说明有重叠部分，就拿着合并后的这个和下一个合并
                if (mergedList.Count() == 1)
                {
                    previous = mergedList.FirstOrDefault();
                }
                else
                {
                    previous = mergedList.Last();
                    i++;
                }

                result.Add(mergedList.FirstOrDefault());

                next = rangeList[j];
            }

            return result;
        }

        public static IEnumerable<DateTimeRange> GetMergedRange(DateTimeRange previous, DateTimeRange next)
        {
            if (previous.StartDateTime <= next.StartDateTime)
            {
                //previous:|------------|
                //next    :                 |---------------|
                if (previous.EndDateTime > next.StartDateTime)
                {
                    yield return new DateTimeRange { StartDateTime = previous.StartDateTime, EndDateTime = previous.EndDateTime };
                    yield return new DateTimeRange { StartDateTime = next.StartDateTime, EndDateTime = next.EndDateTime };
                }
                //previous:|-----------------------|
                //next    :   |---------------|
                else if (previous.EndDateTime < next.EndDateTime)
                {
                    yield return new DateTimeRange { StartDateTime = previous.StartDateTime, EndDateTime = previous.EndDateTime };
                }
                //previous:|----------------|
                //next    :     |---------------|
                else
                {
                    yield return new DateTimeRange { StartDateTime = previous.StartDateTime, EndDateTime = next.EndDateTime };
                }
            }
            else
            {
                //previous:                     |------------|
                //next    :|------------|
                if (previous.StartDateTime > next.EndDateTime)
                {
                    yield return new DateTimeRange { StartDateTime = previous.StartDateTime, EndDateTime = previous.EndDateTime };
                    yield return new DateTimeRange { StartDateTime = next.StartDateTime, EndDateTime = next.EndDateTime };
                }
                //previous:     |------------|
                //next    :|------------------------|
                else if (previous.EndDateTime < next.EndDateTime)
                {
                    yield return new DateTimeRange { StartDateTime = next.StartDateTime, EndDateTime = next.EndDateTime };
                }
                //previous:         |------------|
                //next    :|------------|
                else
                {
                    yield return new DateTimeRange { StartDateTime = next.StartDateTime, EndDateTime = previous.EndDateTime };
                }
            }
        }
    }

    public class DateTimeRange
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
