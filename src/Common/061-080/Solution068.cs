using System;
using System.Linq;

namespace Common
{
    public class Solution068
    {
        public static int CalculateBishopAttacks((int, int)[] bishops) => bishops.Select(item => bishops.Where(g => g.Item1 < item.Item1)
        .Where(g => (Math.Abs((double)g.Item1 / item.Item1) == Math.Abs((double)g.Item2 / item.Item2))).Count()).Sum();
    }
}