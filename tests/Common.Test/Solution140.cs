using System.Collections.Generic;
using System.Linq;

namespace Common
{
    internal static class Solution140
    {
        internal static IEnumerable<int> FindUnique(int[] array)
        {
            // return FindUniqueTheEasyWay(array);
            // return FindUniqueTheMediumWay(array);
            return FindUniqueTheXorWay(array);
        }
        private static IEnumerable<int> FindUniqueTheEasyWay(int[] array)
            => array.GroupBy(n => n).Where(g => g.Count() == 1).Select(k => k.Key);
        private static IEnumerable<int> FindUniqueTheMediumWay(int[] array)
        {
            var dict = new Dictionary<int, int> { };
            foreach (var item in array)
            {
                dict[item]++;
            }
            var ret = new List<int>();
            foreach (var item in dict)
            {
                if (item.Value == 1)
                {
                    ret.Add(item.Key);
                }
            }
            return ret;
        }
        private static IEnumerable<int> FindUniqueTheXorWay(int[] array)
        {
            int xor = array.Aggregate(0, (x, i) => x ^= i);
            // Convert.ToString(xor,2).WriteHost();
            int v = ~(xor - 1);
            // Convert.ToString(v,2).WriteHost();
            int setBit = xor & v;
            // Convert.ToString(setBit,2).WriteHost();
            int a = 0;
            int b = 0;
            foreach (var item in array)
            {
                if ((item & setBit) == setBit) { a ^= item; }
                else { b ^= item; }
            }
            return new[] { a ^ 0, b ^ 0 };
        }
    }
}