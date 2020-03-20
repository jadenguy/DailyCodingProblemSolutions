

using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Solution138
    {
        public static int MinimumCoinCount(this int[] denominations, int value) => MinimumCoinCount(denominations, value, out _);
        public static int MinimumCoinCount(this int[] denominations, int value, out Dictionary<int, int[]> table)
        {
            table = denominations.ToDictionary(k => k, v=>new[]{v});
            return ReuseDictionaryMinimumCoinCount(denominations, value, ref table);
        }
        public static int ReuseDictionaryMinimumCoinCount(this int[] denominations, int target, ref Dictionary<int, int[]> table)
        {
            var values = new Stack<int>() { };
            values.Push(target);
            while (values.Count > 0)
            {
                var value = values.Pop();
                foreach (var coin in denominations)
                {
                    int otherCoins = value - coin;
                    if (otherCoins == 0)
                    {
                        table[coin] = new[] { coin };
                    }
                    else if (table.ContainsKey(otherCoins))
                    {
                        int[] bestCoinResult = table[otherCoins].Concat(new[] { coin }).ToArray();
                        bool isUpdateable = table.TryGetValue(value, out var currentValue);
                        if (isUpdateable)
                        {
                            var current = currentValue.Length;
                            var potentialBestScore = table[otherCoins].Length + 1;
                            if (current < potentialBestScore)
                            {
                                bestCoinResult = table[value];
                            }
                        }
                        else
                        {
                            table[value] = bestCoinResult;
                        }
                    }
                    else if (otherCoins > 0)
                    {
                        values.Push(value);
                        values.Push(otherCoins);
                    }
                    else {; }
                }
                values = new Stack<int>(values.Distinct().OrderByDescending(v => v));
            }
            return table[target].Count();
        }
    }
}