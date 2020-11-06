using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution147
    {
        static T[] Reverse<T>(this IEnumerable<T> lst, int i, int j)
        {
            var len = j - i;
            T[] ret = lst.ToArray();
            for (int delta = 0; delta < len - (len / 2); delta++)
            {
                (ret[i + delta], ret[j - delta]) = (ret[j - delta], ret[i + delta]);
            }
            return ret;
        }

        public static T[] SortWithReverseOnly<T>(T[] array) where T : IComparable<T>
        {
            // array.Print(",").WriteHost();
            var len = array.Length;
            // var changes = 0;

            // Solution147.Reverse(array, 0, 9).Print(",").WriteHost();
            for (int r = 0; r < len; r++)
            {
                int rIndex = len - 1 - r;
                for (int i = 0; i < rIndex; i++)
                {
                    if (array[i].CompareTo(array[rIndex]) > 0)
                    {
                        // array.Print(",").WriteHost($"reverse {i} to {rIndex}");
                        array = Reverse(array, i, rIndex);
                        // array.Print(",").WriteHost("changed");
                        // changes++;
                    }
                }
            }
            return array;
        }
    }
}