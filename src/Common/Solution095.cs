using System;

namespace Common
{
    public static class Solution095
    {
        public static T[] NextLexicographically<T>(T[] array) where T : IComparable<T>
        {
            var length = array.Length;
            var inversion = -1;
            if (length >= 2)
            {
                bool hasInversion = TryFindInversion(array, out inversion);
                bool hasOrdered = TryFindFirstOrdered(array, out var ordered, inversion);
                if (!hasOrdered && !hasInversion)
                {
                    System.Diagnostics.Debug.WriteLine("two items in list are equal, all permutations are identical");
                }
                else if (hasInversion && hasOrdered)
                {
                    // System.Diagnostics.Debug.WriteLine("WIP");
                    var firstGreaterThanOrderedAfterOrdered = FirstGreaterThanOrderedAfterOrdered(array, ordered);
                    Swap(array, ordered, firstGreaterThanOrderedAfterOrdered);
                    Reverse(array, ordered + 1, array.Length - ordered - 2);
                }
                else if (hasInversion)
                {
                    Reverse(array);
                }
                else if (hasOrdered)
                {
                    Swap(array, ordered + 1, ordered);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("how are you here?");
                }
            }
            return array;
        }
        private static int FirstGreaterThanOrderedAfterOrdered<T>(T[] array, int ordered) where T : IComparable<T>
        {
            var o = array[ordered];
            int i = array.Length - 1;
            while (array[i].CompareTo(o) <= 0) { i--; }
            return i;
        }
        private static void Reverse<T>(T[] array, int start = 0, int count = -1) where T : IComparable<T>
        {
            if (count == -1) { count = array.Length - start - 1; }
            for (int i = 0; i <= count / 2; i++)
            {
                array.Swap(start + i, start + count - i);
            }
        }
        private static void Swap<T>(this T[] array, int i, int o)
        {
            if (i == o) { return; }
            var temp = array[i];
            array[i] = array[o];
            array[o] = temp;
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
            if (!ret) { i = length - 1; }
            return ret;
        }
        private static bool TryFindFirstOrdered<T>(T[] array, out int o, int length = -1) where T : IComparable<T>
        {
            bool ret = false;
            if (length == -1) { length = array.Length - 1; }
            o = length;
            while (!ret && o >= 1)
            {
                var left = array[o - 1];
                var right = array[o];
                ret = left.CompareTo(right) < 0;
                o--;
            }
            if (!ret)
            {
                o = 0;
            }
            return ret;
        }
    }
}