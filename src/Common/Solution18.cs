using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Solution18
    {
        public static int[] PrintMaxValues(int[] input, int k)
        {
            var x = new List<int>();
            var considering = new int[k];
            for (int i = 0; i < k; i++)
            {
                considering[i % k] = input[i];
                System.Diagnostics.Debug.WriteLine(input[i]);
            }
            for (int i = k - 1; i < input.Length; i++)
            {
                considering[i % k] = input[i];
                System.Console.WriteLine(considering.Max());
                x.Add(considering.Max());
            }
            return x.ToArray();
        }
    }
}