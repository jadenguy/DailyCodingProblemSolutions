using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution12
    {
        public static int CountStepPatterns(int stairs, int[] steps)
        {
            int[] count = new int[stairs + 1];
            count[0] = 1;
            for (int i = 1; i <= stairs; i++)
            {
                for (int j = 0; j < steps.Length; j++)
                {
                    int v = steps[j];
                    if (i >= v)
                    {
                        count[i] += count[i - v];
                    }
                }
            }
            return count[stairs];
        }
    }
}