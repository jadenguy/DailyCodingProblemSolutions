using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Test
{
    public static class Solution4
    {
        public static int cycles = 0;
        public static int MissingPositiveIntegerChain(int[] list)
        {
            cycles = 0;
            int length = list.Length;
            var ret = length + 1;
            for (int i = 0; i < length; i++)
            {
                ChainListSort(ref list, length, i);
                cycles++;
            }
            for (int i = 0; i < length; i++)
            {
                if (list[i] != i + 1) { ret = Math.Min(ret, i + 1); }
                cycles++;
            }
            System.Diagnostics.Debug.WriteLine(cycles);
            return ret;
        }

        private static void ChainListSort(ref int[] list, int length, int i)
        {
            cycles++;
            var currentValue = list[i];
            int nextValue = list.ElementAtOrDefault(currentValue - 1);
            if (currentValue != i + 1)
            {
                if (currentValue <= 0 || currentValue > length || nextValue == i + 1) { list[i] = 0; }
                else if (i < length - 1)
                {
                    list[i] = nextValue;
                    list[currentValue - 1] = currentValue;
                    ChainListSort(ref list, length, i + 1);
                }
            }
        }
    }
}