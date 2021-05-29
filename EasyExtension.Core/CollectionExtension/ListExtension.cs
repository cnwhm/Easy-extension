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
    }
}
