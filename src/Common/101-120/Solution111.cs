using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution111
    {
        public static IEnumerable<int> FindAnagramSubstringIndexes<T>(IEnumerable<T> subset, IEnumerable<T> set)
        {
            int subsetLength = subset.Count();
            var wanted = subset.ToHashSet();
            var x = set.SequentialSubsetsOfLength(subsetLength);
            return x.Where(v => v.Value.SetEquals(subset)).Select(v => v.Key);
        }
        private static IEnumerable<(int Key, HashSet<T> Value)> SequentialSubsetsOfLength<T>(this IEnumerable<T> set, int subsetLength)
        {
            var x = new Dictionary<int, HashSet<T>>();
            for (int i = 0; i <= set.Count() - subsetLength; i++)
            {
                var proposed = set.Skip(i).Take(subsetLength).ToHashSet();
                yield return (i, proposed);
            }
        }
    }
}