using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution147
    {
        public static T[] Reverse<T>(IEnumerable<T> lst, int i, int j)
        {
            var len = j - i;
            T[] ret = lst.ToArray();
            for (int delta = 0; delta < len / 2; delta++)
            {
                (ret[i + delta], ret[j - delta]) = (ret[j - delta], ret[i + delta]);
            }
            return ret;
        }
        public static object SortWithReverseOnly(){return null;}
    }
}