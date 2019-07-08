using System.Collections.Generic;
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
    }
}