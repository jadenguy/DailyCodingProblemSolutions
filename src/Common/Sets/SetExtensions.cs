using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common.Sets
{
    public static class SetExtensions
    {
        public class GroupComparer<T> : IEqualityComparer<IGrouping<T, T>> where T : IEquatable<T>
        {
            public bool Equals(IGrouping<T, T> x, IGrouping<T, T> y) => x.Key.Equals(y.Key) && x.Count() == y.Count();

            public int GetHashCode(IGrouping<T, T> obj) => obj.Print().GetHashCode();
        }
        public static bool SetEquivalent<T>(this IEnumerable<T> a, IEnumerable<T> b) where T : IEquatable<T>
        {

            var notOnB = a.Except(b);
            var notOnA = b.Except(a);
            var enumerable = a.GroupBy(k => k).ToArray();
            var second = b.GroupBy(k => k).ToArray();
            GroupComparer<T> comparer = new GroupComparer<T>();
            var differnetCountOnB = enumerable.Except(second, comparer);
            var differentCountOnA = second.Except(enumerable, comparer);
            return a.Count() == b.Count() && !notOnB.Any() && !notOnA.Any() && !differnetCountOnB.Any() && !differentCountOnA.Any();
        }
        public static IEnumerable<T[]> ToArrays<T>(this IEnumerable<T> group) => group.Select(e => new T[] { e });
        public static IEnumerable<T> Xor<T>(this IEnumerable<T> a, IEnumerable<T> b) where T : IEquatable<T>
        {
            var aGroup = a.GroupBy(k => k).ToArray();
            var bGroup = b.GroupBy(k => k).ToArray();
            var uniqueElements = a.Union(b).Distinct().ToArray();
            foreach (var elementKey in uniqueElements)
            {
                var matchA = aGroup.Where(k => k.Key.Equals(elementKey)).SelectMany(x => x).ToArray();
                var matchB = bGroup.Where(k => k.Key.Equals(elementKey)).SelectMany(x => x).ToArray();
                int val1 = matchA.Length;
                int val2 = matchB.Length;
                var repeats = Math.Abs(val1 - val2);
                foreach (var element in Enumerable.Repeat(elementKey, repeats))
                {
                    yield return element;
                }
            }
        }
        public static IEnumerable<T> Not<T>(this IEnumerable<T> a, IEnumerable<T> b) where T : IEquatable<T>
        {
            var aGroup = a.GroupBy(k => k).ToArray();
            var bGroup = b.GroupBy(k => k).ToArray();
            var uniqueElements = a.Union(b).Distinct();
            foreach (var elementKey in uniqueElements)
            {
                var matchA = aGroup.Where(k => k.Key.Equals(elementKey)).SelectMany(x => x).Count();
                var matchB = bGroup.Where(k => k.Key.Equals(elementKey)).SelectMany(x => x).Count();
                var repeats = Math.Max(matchA - matchB, 0);
                foreach (var element in Enumerable.Repeat(elementKey, repeats))
                {
                    yield return element;
                }
            }
        }
        public static IEnumerable<T> And<T>(this IEnumerable<T> a, IEnumerable<T> b) where T : IEquatable<T>
        {
            var aGroup = a.GroupBy(k => k).ToArray();
            var bGroup = b.GroupBy(k => k).ToArray();
            var uniqueElements = a.Union(b).Distinct();
            foreach (var elementKey in uniqueElements)
            {
                var repeats = Math.Min(aGroup.Where(k => k.Key.Equals(elementKey)).Count(), bGroup.Where(k => k.Key.Equals(elementKey)).Count());
                foreach (var element in Enumerable.Repeat(elementKey, repeats))
                {
                    yield return element;
                }
            }
        }
        public static IEnumerable<T> Or<T>(this IEnumerable<T> a, IEnumerable<T> b) where T : IEquatable<T>
        {
            var aGroup = a.GroupBy(k => k).ToArray();
            var bGroup = b.GroupBy(k => k).ToArray();
            var uniqueElements = a.Union(b).Distinct();
            foreach (var elementKey in uniqueElements)
            {
                var matchA = aGroup.Where(k => k.Key.Equals(elementKey)).SelectMany(x => x).Count();
                var matchB = bGroup.Where(k => k.Key.Equals(elementKey)).SelectMany(x => x).Count();
                var repeats = Math.Max(matchA, matchB);
                foreach (var element in Enumerable.Repeat(elementKey, repeats))
                {
                    yield return element;
                }
            }
        }
    }
}