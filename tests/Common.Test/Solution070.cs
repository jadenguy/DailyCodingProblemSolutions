using System;
using System.Linq;

namespace Common
{
    internal class Solution070
    {
        internal static int PerfectNumber(int n)
        {
            return Enumerable.Range(0, int.MaxValue).Where(k => 10 == k.ToString().Sum(f => int.Parse(f.ToString()))).Take(n).Last();
        }
    }
}