using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution102
    {
        public static int[] ContiguousListSum(int[] list, int k)
        {
            var enumerable = list.EveryContiguousSubset().ToArray();
            foreach (var item in enumerable)
            {
                System.Diagnostics.Debug.WriteLine(item.Print(","));
            }
            var enumerable1 = enumerable.Where(s => s.Sum() == k).ToArray();
            var orderedEnumerable = enumerable1.OrderBy(s => s.Count()).ToArray();
            return orderedEnumerable.FirstOrDefault();
        }
    }
}