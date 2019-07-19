using System;
using System.Linq;

namespace Common
{
    public static class Solution009

    {
        public static bool IsNullOrEmpty(this Array array)
        {
            return (array == null || array.Length == 0);
        }
        public static int LargestSumNonAdjacent(int[] list)
        {
            var ret = 0;
            var i = 0;
            while (i < list.Length)
            {
                list[i] += Math.Max(list.ElementAtOrDefault(i - 3), list.ElementAtOrDefault(i - 2));
                ret = Math.Max(list.ElementAtOrDefault(i - 1), list[i]);
                i++;
            }
            return ret;
        }
    }

}
