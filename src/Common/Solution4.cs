using System;
using System.Collections.Generic;

namespace Common
{
    public static class Solution4
    {
        public static int MissingPositiveInteger(int[] list)
        {
            int length = list.Length;
            var ret = length + 1;
            var comparisons = 0;
            for (int i = 0; i < length; i++)
            {
                comparisons += MoveValueToIndex(ref list, length, i);
            }
            for (int i = 0; i < length; i++)
            {
                if (list[i] != i + 1) { ret = Math.Min(ret, i + 1); }
            }
            System.Console.WriteLine($"{comparisons} comparisons for {length} items");
            return ret;
        }
        private static int MoveValueToIndex(ref int[] list, int length, int i)
        {
            var comparisons = 1;
            var currentValue = list[i];
            var valueIsValid = (currentValue <= length && currentValue > 0);
            int nextValue = NextValueOrDefault(list, currentValue, valueIsValid);
            if (currentValue != i + 1)
            {
                if (!valueIsValid || nextValue == currentValue) { list[i] = 0; }
                else if (i < length)
                {
                    if (nextValue <= length) { list[i] = nextValue; }
                    else { list[i] = 0; }
                    list[currentValue - 1] = currentValue;
                    // comparisons += MoveValidToRightPosition(ref list, length, i); //Uncomment to sort list where gaps equal 0
                }
            }
            return comparisons;
        }

        private static int NextValueOrDefault(int[] list, int currentValue, bool valueIsValid)
        {
            int nextValue = 0;
            if (valueIsValid) { nextValue = list[currentValue - 1]; }
            return nextValue;
        }
    }
}