using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common.Sets
{
    public static class SetExensions
    {

        class SetGroupedComparer : IEqualityComparer<IGrouping<SetElement, SetElement>>
        {
            public bool Equals(IGrouping<SetElement, SetElement> x, IGrouping<SetElement, SetElement> y) => (x.Key.Equivalent(y.Key) && x.Count() == y.Count());
            public int GetHashCode(IGrouping<SetElement, SetElement> obj) => obj.Print().GetHashCode();
        }
        public static bool SetEquivalent(this IEnumerable<SetElement> a, IEnumerable<SetElement> b)
        {
            SetElementComparer elementComparer = new SetElementComparer();
            SetGroupedComparer groupComparer = new SetGroupedComparer();
            var notOnB = a.Except(b, elementComparer);
            var notOnA = b.Except(a, elementComparer);
            var differnetCountOnB = a.GroupBy(k => k, elementComparer).Except(b.GroupBy(k => k, elementComparer), groupComparer);
            var differentCountOnA = b.GroupBy(k => k, elementComparer).Except(a.GroupBy(k => k, elementComparer), groupComparer);
            return a.Count() == b.Count() && !notOnB.Any() && !notOnA.Any() && !differnetCountOnB.Any() && !differentCountOnA.Any();
        }
        public static IEnumerable<SetElement> Not(this IEnumerable<SetElement> a) => a.Select(k => k.XorElement());
        private static IEnumerable<SetElement> Xor(this IEnumerable<SetElement> b) => b.Select(k => k.NotElement());
        private static IEnumerable<SetElement> NotXor(this IEnumerable<SetElement> b) => b.Select(k => k.NotXorElement());
        public static IEnumerable<SetElement> Xor(this IEnumerable<SetElement> a, IEnumerable<SetElement> b) => new Set(a.Union(b.Not()));
        public static IEnumerable<SetElement> Not(this IEnumerable<SetElement> a, IEnumerable<SetElement> b) => new Set(a.Union(b.Xor()));
        public static IEnumerable<SetElement> And(this IEnumerable<SetElement> a, IEnumerable<SetElement> b)
        {
            SetElementComparer elementComparer = new SetElementComparer();
            SetGroupedComparer groupComparer = new SetGroupedComparer();
            var aGroup = a.GroupBy(k => k, elementComparer);
            var bGroup = b.GroupBy(k => k, elementComparer);
            var uniqueElements = a.Union(b).Distinct(elementComparer);
            foreach (var elementKey in uniqueElements)
            {
                var repeats = Math.Min(aGroup.Where(k => k.Key.Equivalent(elementKey)).Count(), bGroup.Where(k => k.Key.Equivalent(elementKey)).Count());
                foreach (var element in Enumerable.Repeat(elementKey, repeats))
                {
                    yield return element;
                }
            }
        }
        public static IEnumerable<SetElement> Or(this IEnumerable<SetElement> a, IEnumerable<SetElement> b)
        {
            SetElementComparer elementComparer = new SetElementComparer();
            SetGroupedComparer groupComparer = new SetGroupedComparer();
            var aGroup = a.GroupBy(k => k, elementComparer);
            var bGroup = b.GroupBy(k => k, elementComparer);
            var uniqueElements = a.Union(b).Distinct(elementComparer);
            foreach (var elementKey in uniqueElements)
            {
                var matchA = aGroup.Where(k => k.Key.Equivalent(elementKey)).SelectMany(x => x);
                var matchB = bGroup.Where(k => k.Key.Equivalent(elementKey)).SelectMany(x => x);
                int val1 = matchA.Count();
                int val2 = matchB.Count();
                var repeats = Math.Max(val1, val2);
                foreach (var element in Enumerable.Repeat(elementKey, repeats))
                {
                    yield return element;
                }
            }
        }
    }
}