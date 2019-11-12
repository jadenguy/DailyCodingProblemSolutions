using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution074
    {
        public static int FindRepetitionsInTimesTable(int n, int x)
        {
            var ret = 0;
            var sqrt = Math.Sqrt(x);
            int[] factors = Factorize(x).ToArray();
            ret = factors.Where(f => f <= n && f >= sqrt).Count() * 2;
            if (n == sqrt) { ret--; }
            return ret;
        }
        private static IEnumerable<int> Factorize(int x)
        {
            for (int i = 1; i <= x; i++)
            {
                if (x % i == 0)
                {
                    yield return i;
                }
            }
        }
        public static int FindRepetitionsInTimesTableNaive(int n, int x)
        {
            return Enumerable.Range(1, n).SelectMany(i => Enumerable.Range(1, n).Select(j => j * i)).Where(s => s == x).Count();
        }
    }
}