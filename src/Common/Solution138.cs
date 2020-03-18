
using System;
using System.Linq;

namespace Common
{
    public static class Solution138
    {
        public static int MinimumCoinCount(this int[] denominations, int value)
        {
            var coins = denominations.OrderByDescending(n => n).ToArray();
            for (int i = 0; i < coins.Length; i++)
            {
                
            }
            var ret = 0;
            return ret;
        }
    }
}