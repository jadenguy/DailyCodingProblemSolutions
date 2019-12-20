using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution102
    {
        public static int[] ContiguousListSum(int[] list, int k)
        {
            int[] ret = null;
            var g = list.EveryContiguousSubset().Where(s => s.Sum() == k).OrderBy(s => s.Count());
            return ret;
        }
    }
}