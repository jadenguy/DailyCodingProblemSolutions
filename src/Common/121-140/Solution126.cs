using System;

namespace Common
{
    public static class Solution126
    {
        public static int[] RotateArray(int[] a, int k)
        {
            int length = a.Length;
            while (k < 0) { k += length; }
            k %= length;
            if (k != 0)
            {
                int cycleCount, cycleSize;
                if (length % k == 0)
                {
                    cycleCount = (length / k) - 1;
                    cycleSize = k;
                }
                else
                {
                    cycleCount = 1;
                    cycleSize = length - 1;
                }
                for (int i = 0; i < cycleCount; i++)
                {
                    int future, current = i;
                    for (int j = 0; j < cycleSize; j++)
                    {
                        future = (current + k) % length;
                        (a[current], a[future]) = (a[future], a[current]);
                        current = future;
                    }
                }
            }
            return a;
        }
    }
}