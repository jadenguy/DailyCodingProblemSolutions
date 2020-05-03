using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Solution143
    {
        public static IEnumerable<IEnumerable<int>> Partition(int x, int[] lst)
        {
            return new[] { lst.Where(n => n < x)
                    ,lst.Where(n => n== x)
                    ,lst.Where(n => n > x)
                };
        }
    }
}