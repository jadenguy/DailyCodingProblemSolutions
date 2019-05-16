using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution2
    {
        public static object ProductOfOther(int[] list)
        {
            var ret = new List<int>() { };
            var count = list.Length;
            if (count == 1) { ret.Add(0); }
            if (count > 1)
            {
                for (int i = 0; i < count; i++)
                {
                    var product = 1;
                    for (int j = 0; j < count; j++)
                    {
                        if (i != j) { product *= list[j]; }
                    }
                    ret.Add(product);
                }
            }
            return ret.ToArray();
        }
    }
}