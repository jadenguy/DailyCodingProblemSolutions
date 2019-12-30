using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Solution111
    {
        public static IEnumerable<int> FindAnagramSubstringIndexes<T>(IEnumerable<T> subset, IEnumerable<T> set)
        {
            int subsetLength = subset.Count();
            int setLength = set.Count();
            var wanted = subset.ToHashSet();
            for (int i = 0; i <= setLength - subsetLength; i++)
            {
                var proposed = set.Skip(i).Take(subsetLength).ToArray();
                if (proposed.ToHashSet().SetEquals(wanted))
                {
                    yield return i;
                }
            }
        }
    }
}