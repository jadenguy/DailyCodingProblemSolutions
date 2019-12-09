using System;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution095
    {
        public static T[] NextLexicographically<T>(T[] array) where T : IComparable<T>
        {
            var length = array.Length;
            var inversion = 0;
            if (length >= 2)
            {

                bool hasInversion;
                if (hasInversion = TryFindInversion(array, out inversion))
                {

                    System.Diagnostics.Debug.WriteLine(array[inversion], $"Value at {nameof(inversion)}");
                }
                System.Diagnostics.Debug.WriteLine(inversion, nameof(inversion));
                bool hasOrdered;
                if (hasOrdered = TryFindFirstOrdered(array, out var ordered, inversion - 1))
                {
                    System.Diagnostics.Debug.WriteLine(array[ordered], $"Value at {nameof(ordered)}");
                    System.Diagnostics.Debug.WriteLine(ordered, nameof(ordered));
                }
                // if (!hasOrdered && !hasInversion)
                // {
                //     System.Diagnostics.Debug.WriteLine("not changeable");
                // }
                // System.Diagnostics.Debug.WriteLine(hasInversion, nameof(hasInversion));
                // System.Diagnostics.Debug.WriteLine(hasOrdered, nameof(hasOrdered));
                // if (hasInversion && hasOrdered)
                // {
                //     System.Diagnostics.Debug.WriteLine("WIP");
                //     var x = LowerGreaterThanFirstOrdered(array, ordered);
                //     Swap(array, inversion, x, true);
                //     Reverse(array, array.Length - inversion);
                // }
                // else if (hasInversion)
                // {
                //     Reverse(array, array.Length);
                // }
                // else if (hasOrdered)
                // {
                //     Swap(array, ordered + 1, ordered, true);
                // }
                // else
                // {
                //     System.Diagnostics.Debug.WriteLine("two items in list are equal, all permutations are identical");
                // }
            }
            return array;
        }
        // private static int LowerGreaterThanFirstOrdered<T>(T[] array, int ordered) where T : IComparable<T>
        // {
        //     var i = array.Length;
        //     T t;
        //     T t1 = array[ordered];
        //     int v;
        //     do
        //     {
        //         i--;
        //         t = array[i];

        //         v = t.CompareTo(t1);
        //         System.Diagnostics.Debug.WriteLine(t, "candidate");
        //         System.Diagnostics.Debug.WriteLine(v, "isGreater");
        //     }
        //     while (v < 0);
        //     return i;
        // }
        private static void Reverse<T>(T[] array, int count = -1, int start = 0) where T : IComparable<T>
        {
            if (count == -1) { count = array.Length; }
            for (int k = start; k < count / 2; k++)
            {
                array.Swap(count - k - 1, k, true);
            }
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
        private static bool TryFindInversion<T>(T[] array, out int i, int length = -1) where T : IComparable<T>
        {
            bool ret = false;
            if (length == -1) { length = array.Length; }
            i = length - 1;
            while (!ret && i >= 1)
            {
                var left = array[i - 1];
                var right = array[i];
                ret = left.CompareTo(right) > 0;
                i--;
            }
            if (!ret)
            {
                i = length - 1;
            }
            return ret;
        }
        private static bool TryFindFirstOrdered<T>(T[] array, out int j, int length = -1) where T : IComparable<T>
        {
            bool ret = false;
            if (length == -1) { length = array.Length; }
            j = length - 1;
            while (!ret && j >= 1)
            {
                var left = array[j - 1];
                var right = array[j];
                ret = left.CompareTo(right) < 0;
                j--;
            }
            if (!ret)
            {
                j = length - 1;
            }
            return ret;
        }
    }
}