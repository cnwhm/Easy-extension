using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EasyExtension
{
    public static class ListExtension
    {
        public static List<TResult> ToList<TSource, TResult>(this List<TSource> list, Func<TSource, TResult> predicate)
        {
            return list.Select(predicate).ToList();
        }

        /// <summary>
        /// unchecked
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="list"></param>
        /// <param name="numberPerPage"></param>
        /// <param name="totalPage"></param>
        /// <returns></returns>
        public static List<List<TResult>> PageList<TResult>(this List<TResult> list, int numberPerPage, int totalPage)
        {
            var lstSpan = new List<List<TResult>>();

            for (int i = 0; i < totalPage; i += numberPerPage)
            {
                lstSpan.Add(list.Skip(i).Take(numberPerPage).ToList());
            }

            return lstSpan;
        }
    }
}
