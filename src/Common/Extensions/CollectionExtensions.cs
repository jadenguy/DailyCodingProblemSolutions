using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Common.Extensions
{

    public static class CollectionExtensions
    {
        [System.Diagnostics.DebuggerStepThrough] public static IEnumerable<T> TakeSub<T>(this IEnumerable<T> enumerable, int start, int length = 1) => enumerable.Skip(start).Take(length);
        [System.Diagnostics.DebuggerStepThrough] public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> enumerable, int i) => enumerable.Reverse().Take(i).Reverse();
        [System.Diagnostics.DebuggerStepThrough] public static string Print<T>(this IEnumerable<T> enumerable, string seperator = "\n") => string.Join(seperator, enumerable);
        [System.Diagnostics.DebuggerStepThrough] public static IEnumerable<T> Random<T>(this IEnumerable<T> e, Random rand = null) => e.OrderBy(r => (rand ?? new Random()).Next());
        [System.Diagnostics.DebuggerStepThrough]
        public static void Reverse<T>(this T[] array, int start = 0, int count = -1) where T : IComparable<T>
        {
            if (count == -1) { count = array.Length - start - 1; }
            for (int i = 0; i <= count / 2; i++)
            {
                array.Swap(start + i, start + count - i);
            }
        }
        [System.Diagnostics.DebuggerStepThrough]
        public static void Swap<T>(this T[] array, int i, int o)
        {
            if (i == o) { return; }
            var temp = array[i];
            array[i] = array[o];
            array[o] = temp;
        }

        [System.Diagnostics.DebuggerStepThrough]
        public static bool TryPeek<T>(this Queue<T> queue, out T peek)
        {
            var ret = false;
            peek = default(T);
            try
            {
                peek = queue.Peek();
                ret = true;
            }
            catch { }
            return ret;
        }
        [System.Diagnostics.DebuggerStepThrough]
        public static IEnumerable<T> StreamSlowly<T>(this IEnumerable<T> e, int milliseconds)
        {
            foreach (var item in e)
            {
                Thread.Sleep(milliseconds);
                yield return item;
            }
        }
        [System.Diagnostics.DebuggerStepThrough]
        public static IEnumerable<T[]> EverySubset<T>(this IEnumerable<T> enumerable)
        {
            var source = enumerable.ToArray();
            int length = source.Length;
            for (int i = 0; i < Math.Pow(2, length); i++)
            {
                List<T> combination = new List<T> { };
                for (int j = 0; j < length; j++)
                {
                    if ((i & 1 << length - j - 1) != 0)
                    {
                        combination.Add(source[j]);
                    }
                }
                yield return combination.ToArray();
            }
        }
        [System.Diagnostics.DebuggerStepThrough]
        public static IEnumerable<T[]> EveryContiguousSubset<T>(this IEnumerable<T> enumerable)
        {
            yield return new T[] { };
            for (int i = 0; i < enumerable.Count(); i++)
            {
                for (int j = 1; j + i - 1 < enumerable.Count(); j++)
                {
                    var subset = enumerable.Skip(i).Take(j);
                    yield return subset.ToArray();
                }
            }
        }
        [System.Diagnostics.DebuggerStepThrough] public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable) => new HashSet<T>(enumerable);
        [System.Diagnostics.DebuggerStepThrough] public static HashSet<TOut> ToHashSet<TIn, TOut>(this IEnumerable<TIn> enumerable, Func<TIn, TOut> func) => new HashSet<TOut>(enumerable.Select(e => func(e)));
        [System.Diagnostics.DebuggerStepThrough]
        public static void Fill<T>(this T[] array, T value)
        {
            for (int i = 0; i < array.Length; i++) { array[i] = value; }
        }
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> array) => (array is null || !array.Any());
        [System.Diagnostics.DebuggerStepThrough]
        public static IEnumerable<T[]> EveryPermutation<T>(this IEnumerable<T> enumerable) where T : IEquatable<T>
        {
            if (enumerable.Count() == 1) { yield return enumerable.ToArray(); }
            else
            {
                for (int i = 0; i < enumerable.Count(); i++)
                {
                    var permutation = new List<T>(enumerable);
                    permutation.RemoveAt(i);
                    foreach (var item in permutation.EveryPermutation())
                    {
                        yield return (new List<T>(item) { enumerable.ElementAt(i) }).ToArray();
                    }
                }
            }
        }
    }
}