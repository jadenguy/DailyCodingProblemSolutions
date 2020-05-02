using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Solution140
    {
        public static IEnumerable<int> FindUniquePair(int[] array)
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
            // XOR the whole list, to get a XOR of unique pairs
            int xor = array.Aggregate(0, (x, i) => x ^= i);
            // Convert.ToString(xor,2).WriteHost();
            // subtracting one from a number takes all the rightmost 0s 
            // and turns them into 1, and the first 1 to a 0
            // the opposite of that is for the first 1 to be a 1, all
            // of the remaining 0s to 1s, so the left half is reverse
            // the first 1 is a 1, and the right is all 0s.
            // when you and that against itself you get the first one
            // because the left half is opposite and the right half
            // is all zeros.
            int v = ~(xor - 1);
            // Convert.ToString(v,2).WriteHost();
            int setBit = xor & v;
            // Convert.ToString(setBit,2).WriteHost();
            int a = 0;
            int b = 0;
            // the XOR of a list of doubles and two singles is the XOR
            // of just the two singles, the others cancel out.
            // by definition, the 1s are unique to each number, so by
            // picking a random (leftmost) 1, we can make two sets:
            // numbers that have the bit set and numbers that don't.
            // because pairs will XOR out, it doesn't matter where 
            // they go. The unique ones will thus separate themselves.
            foreach (var item in array)
            {
                if ((item & setBit) == setBit) { a ^= item; }
                else { b ^= item; }
            }
            return new[] { a ^ 0, b ^ 0 };
        }
    }
}