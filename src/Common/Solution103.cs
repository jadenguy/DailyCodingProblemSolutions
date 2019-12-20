using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution103
    {
        public static T[] ShortestInclusiveSubset<T>(T[] list, T[] desiredElements) where T: IEquatable<T>
        {
            var desiredSet =new HashSet<T>(desiredElements);
            return list.EveryContiguousSubset().Where(l => new HashSet<T>(l).IsSupersetOf(desiredSet)).OrderBy(r => r.Length).FirstOrDefault();
        }
    }
}