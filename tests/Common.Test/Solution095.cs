using System;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution095
    {
        public static T[] NextLexicographically<T>(T[] array) where T : IComparable<T>
        {
            int length = array.Length;
            bool foundInversion = false;
            var ret = array;
            System.Diagnostics.Debug.WriteLine(array.Print(" "));
            int i;
            if (length >= 2)
            {
                if (TryFindInversion(array, out i))
                {
                    System.Diagnostics.Debug.WriteLine(i);
                }
                {
                    array.Swap(0, 1, true);
                }
            }
            System.Diagnostics.Debug.WriteLine(foundInversion);
            return ret.ToArray();
        }
        private static bool TryFindFirstOrdered<T>(T[] array, out int j, int i = 0) where T : IComparable<T>
        {
            bool ret = false;
            var length = array.Length;
            j = i;
            while (!ret && j < length - 1)
            {
                int v = length - j - 1;
                var left = array[v - 1];
                var right = array[v];
                ret = left.CompareTo(right) < 0;
                j++;
            }
            return ret;
        }
        private static void Swap<T>(this T[] array, int i, int j, bool inverse = false)
        {
            if (i == j) { return; }
            var length = array.Length;
            var l = i;
            var r = j;
            if (inverse)
            {
                l = length - l - 1;
                r = length - r - 1;
            }
            T temp = array[l];
            array[l] = array[r];
            array[r] = temp;
        }
        private static bool TryFindInversion<T>(T[] array, out int i) where T : IComparable<T>
        {
            bool ret = false;
            var length = array.Length;
            i = 0;
            while (!ret && i < length - 1)
            {
                int v = length - i - 1;
                var left = array[v - 1];
                var right = array[v];
                ret = left.CompareTo(right) > 0;
                i++;
            }
            return ret;
        }
    }
}