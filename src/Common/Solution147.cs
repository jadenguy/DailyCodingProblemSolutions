using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution147
    {
        public static T[] Reverse<T>(this IEnumerable<T> lst, int i, int j)
        {
            var len = j - i;
            T[] ret = lst.ToArray();
            for (int delta = 0; delta < len - (len / 2); delta++)
            {
                (ret[i + delta], ret[j - delta]) = (ret[j - delta], ret[i + delta]);
            }
            return ret;
        }

        public static int[] SortWithReverseOnly(int[] array)
        {
            // array.Print(",").WriteHost();
            var len = array.Length;

            // Solution147.Reverse(array, 0, 9).Print(",").WriteHost();
            for (int r = 0; r < len; r++)
            {
                int rIndex = len - 1 - r;
                for (int i = 0; i < rIndex; i++)
                {
                    if (array[i] > array[rIndex])
                    {
                        array.Print(",").WriteHost($"reverse {i} to {rIndex}");
                        array = Reverse(array, i, rIndex);
                        array.Print(",").WriteHost("changed");
                        // i = -1;
                    }
                }
            }
            return array;
        }
    }
}