using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution148
    {
        public static int[] GenerateGrayCode(int bits)
        {
            var ret = new List<int>() { 0, 1 };
            for (int i = 1; i < bits; i++)
            {
                var n = 1 << i;
                var rev = ret.Select(x => x | n).Reverse().ToList();
                ret = ret.Union(rev).ToList();
            }
            return ret.ToArray();
        }
    }
}