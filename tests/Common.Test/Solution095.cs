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
            System.Diagnostics.Debug.WriteLine(array.Print(" "), "source");
            int i;
            if (length >= 2)
            {
                if (!TryFindInversion(array, out i))
                {
                    if (TryFindFirstOrdered(array, out var j))
                    {
                        array.Swap(j, j + 1, true);
                    }
                    // else
                    // {
                    // no inversions and no ordered means it's an array of 2 or more identical members
                    // return array;
                    // }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(i, "inversion at");
                    if (i == 1)
                    {
                        if (TryFindFirstOrdered(array, out var j, i))
                        {
                            array.Swap(j, j + 1, true);
                        }
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine(array.Print(" "), "result");
            return array;
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
            if (ret) { j--; }
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