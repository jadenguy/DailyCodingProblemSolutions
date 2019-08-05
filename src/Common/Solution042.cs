using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public class Solution042
    {
        public static IEnumerable<int[]> SubsetSum(IEnumerable<int> s, int k)
        {
            var elements = s.Where(n => n <= k).OrderBy(l => l).ToArray();
            var arrays = elements.EverySubset();
            return arrays.Where(i => i.Sum() == k);
        }
    }
}