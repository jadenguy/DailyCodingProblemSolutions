using System.Linq;
using Common.Extensions;

namespace Common
{
    public class Solution069
    {
        public static int LargestProductOfThree(int[] array) // brute force
        {
            return array.EverySubset()
                .Where(g => g.Length == 3)
                .Select(r => r.Aggregate(1, (a, b) => a * b))
                .OrderByDescending(r => r)
                .First();
        }
    }
}
