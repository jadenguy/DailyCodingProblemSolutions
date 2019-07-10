using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Extensions
{
    public static class IEnumerableExtension
    {
        public static string Print<T>(this IEnumerable<T> enumerable)
        {
            var ret = new StringBuilder();
            if (enumerable != null)
            {
                foreach (var item in enumerable)
                {
                    ret.AppendLine(item.ToString());
                }
            }
            return ret.ToString();
        }
        public static IEnumerable<T> Random<T>(this IEnumerable<T> e, Random rand = null) => e.OrderBy(r => (rand ?? new Random()).Next());
        public static T RandomFirst<T>(this IEnumerable<T> e, Random rand = null) => e.OrderBy(r => (rand ?? new Random()).Next()).First();
    }
}