using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution130
    {
        public static int BestProfit(int[] array, int k)
        {
            int length = array.Length;
            var buys = Enumerable.Repeat(true, k + k);
            var sells = Enumerable.Repeat(false, length - k - k);
            var buysAndSells = buys.Concat(sells).ToArray();
            var buyAndSellVariations = buysAndSells.StarsAndBars().ToArray();
            return 0;
        }
    }
}