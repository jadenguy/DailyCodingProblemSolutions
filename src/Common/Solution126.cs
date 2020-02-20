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
                var z = (length % k);
                int future, current = 0;
                
                for (int i = 0; i < length; i++)
                {
                    future = (current + k) % length;
                    (a[current], a[future]) = (a[future], a[current]);
                    current = future;
                }
            }
            return a;
        }
    }
}