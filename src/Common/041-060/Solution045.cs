using System;
using System.Linq;

namespace Common
{
    public class Solution045
    {
        public static int Rand5(int seed = 0)
        {
            Random rand = (seed == 0) ? new Random() : new Random(seed);
            return rand.Next(1, 5);
        }
        public static int Rand7(int seed = 0)
        {
            Random rand = (seed == 0) ? new Random() : new Random(seed);
            var x = 1 + (Enumerable.Range(0, 7).Select(k => Rand5(rand.Next())).Sum() % 7);
            return x;
        }
    }
}