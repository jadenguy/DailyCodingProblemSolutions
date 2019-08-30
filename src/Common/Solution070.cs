using System;
using System.Linq;

namespace Common
{
    public class Solution070
    {
        public static int PerfectNumber(int n)
        {
            return Enumerable.Range(0, int.MaxValue).Where(k => 10 == k.ToString().Sum(f => int.Parse(f.ToString()))).Take(n).Last();
        }
    }
}