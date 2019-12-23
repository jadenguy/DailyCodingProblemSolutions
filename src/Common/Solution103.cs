using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution103
    {
        public static T[] ShortestInclusiveSubset<T>(T[] list, T[] desiredElements) where T : IEquatable<T>
        {
            var subsets = list.EveryContiguousSubset();
            var containingSubsets = subsets.Where(l => new HashSet<T>(l).IsSupersetOf(new HashSet<T>(desiredElements)));
            return containingSubsets.OrderBy(r => r.Length).FirstOrDefault();
        }
    }
}