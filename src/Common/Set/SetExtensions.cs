using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common.Sets
{
    public static class SetExensions
    {

        class SetGroupedComparer<T> : IEqualityComparer<IGrouping<SetElement<T>, SetElement<T>>> where T : IEquatable<T>
        {
            public bool Equals(IGrouping<SetElement<T>, SetElement<T>> x, IGrouping<SetElement<T>, SetElement<T>> y) => (x.Key.Equivalent(y.Key) && x.Count() == y.Count());
            public int GetHashCode(IGrouping<SetElement<T>, SetElement<T>> obj) => obj.Print().GetHashCode();
        }
        public static bool SetEquivalent<T>(this IEnumerable<SetElement<T>> a, IEnumerable<SetElement<T>> b) where T : IEquatable<T>
        {
            var elementComparer = new SetElementComparer<T>();
            var groupComparer = new SetGroupedComparer<T>();
            var notOnB = a.Except(b, elementComparer);
            var notOnA = b.Except(a, elementComparer);
            var differnetCountOnB = a.GroupBy(k => k, elementComparer).Except(b.GroupBy(k => k, elementComparer), groupComparer);
            var differentCountOnA = b.GroupBy(k => k, elementComparer).Except(a.GroupBy(k => k, elementComparer), groupComparer);
            return a.Count() == b.Count() && !notOnB.Any() && !notOnA.Any() && !differnetCountOnB.Any() && !differentCountOnA.Any();
        }
        public static IEnumerable<SetElement<T>> ElementsToNewElements<T>(this IEnumerable<SetElement<T>> elements) where T : IEquatable<T> => elements.Select(k => new SetElement<T>(k));
        public static IEnumerable<Set<T>> ElementsToSets<T>(this IEnumerable<SetElement<T>> elements) where T : IEquatable<T> => elements.Select(k => new Set<T>() { k });
        public static IEnumerable<SetElement<T>> TypeEnumerableToElements<T>(this IEnumerable<T> elements) where T : IEquatable<T> => elements.Select(k => new SetElement<T>(k));
        public static IEnumerable<SetElement<T>> Not<T>(this IEnumerable<SetElement<T>> a) where T : IEquatable<T> { return a.Select(k => k.NotElement()); }
        private static IEnumerable<SetElement<T>> Xor<T>(this IEnumerable<SetElement<T>> b) where T : IEquatable<T> => b.Select(k => k.XorElement());
        private static IEnumerable<SetElement<T>> NotXor<T>(this IEnumerable<SetElement<T>> b) where T : IEquatable<T> => b.Select(k => k.NotXorElement());
        public static IEnumerable<SetElement<T>> Xor<T>(this IEnumerable<SetElement<T>> a, IEnumerable<SetElement<T>> b) where T : IEquatable<T> => (a.Xor().Union(b.Xor())).Xor();
        public static IEnumerable<SetElement<T>> Not<T>(this IEnumerable<SetElement<T>> a, IEnumerable<SetElement<T>> b) where T : IEquatable<T> => a.Union(b.Not());
        public static IEnumerable<SetElement<T>> And<T>(this IEnumerable<SetElement<T>> a, IEnumerable<SetElement<T>> b) where T : IEquatable<T>
        {
            var elementComparer = new SetElementComparer<T>();
            var groupComparer = new SetGroupedComparer<T>();
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
        public static IEnumerable<SetElement<T>> Or<T>(this IEnumerable<SetElement<T>> a, IEnumerable<SetElement<T>> b) where T : IEquatable<T>
        {
            var elementComparer = new SetElementComparer<T>();
            var groupComparer = new SetGroupedComparer<T>();
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