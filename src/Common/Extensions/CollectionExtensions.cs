﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Extensions
{
    public static class CollectionExtensions
    {
        [System.Diagnostics.DebuggerStepThrough] public static IEnumerable<T> TakeSub<T>(this IEnumerable<T> enumerable, int start, int length = 1) => enumerable.Skip(start).Take(length);
        [System.Diagnostics.DebuggerStepThrough] public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> enumerable, int i) => enumerable.Reverse().Take(i).Reverse();
        [System.Diagnostics.DebuggerStepThrough]
        public static string Print<T>(this IEnumerable<T> enumerable, string seperator = "\n", Func<T, object> func = null)
            => string.Join(seperator, enumerable.Select(v => (func ?? (o => o))(v)));
        public static string Print<T>(this T[,] enumerable, Func<T, object> func = null)
        {
            func = func ?? (o => o);
            var sb = new System.Text.StringBuilder();
            int xMax = enumerable.GetUpperBound(0);
            int yMax = enumerable.GetUpperBound(1);
            var width = 1 + (enumerable.Cast<T>()).Select(n => func(n)).Max(t => t.ToString().Length);
            for (int x = 0; x <= xMax; x++)
            {
                sb.AppendLine();
                for (int y = 0; y <= yMax; y++)
                {
                    var current = func(enumerable[x, y]);
                    sb.Append(current.ToString().PadLeft(width));
                }
            }
            return sb.ToString();
        }
        [System.Diagnostics.DebuggerStepThrough]
        public static IEnumerable<T[]> EveryPermutation<T>(this IEnumerable<T> enumerable) where T : IEquatable<T>
        {
            if (enumerable.Count() == 1) { yield return enumerable.ToArray(); }
            else
            {
                var dict = enumerable.GroupBy(n => n).ToDictionary(k => k.Key, v => v.Count());
                foreach (var key in dict.Keys)
                {
                    var sub = dict.SelectMany(n => Enumerable.Repeat(n.Key, n.Value - (n.Key.Equals(key) ? 1 : 0)));
                    foreach (var subList in sub.EveryPermutation())
                    {
                        yield return (new List<T>(subList) { key }).ToArray();
                    }
                }
            }
        }
        [System.Diagnostics.DebuggerStepThrough] public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> e, Random rand) => e.OrderBy(r => (rand ?? new Random()).Next());
        [System.Diagnostics.DebuggerStepThrough] public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> e, int seed = 0) => e.Shuffle(seed == 0 ? new Random() : new Random(seed));
        [System.Diagnostics.DebuggerStepThrough]
        public static void Reverse<T>(this T[] array, int start = 0, int count = -1)
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
            (array[i], array[o]) = (array[o], array[i]);
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
                System.Threading.Thread.Sleep(milliseconds);
                yield return item;
            }
        }
        [System.Diagnostics.DebuggerStepThrough]
        public static IEnumerable<T[]> EverySubset<T>(this IEnumerable<T> enumerable)
        {
            var source = enumerable.ToArray();
            int length = source.Length;
            var masks = MathExtensions.GenerateBitMasks(length);
            foreach (var mask in masks)
            {
                List<T> combination = new List<T>();
                for (int i = 0; i < length; i++)
                {
                    if (mask[i])
                    { combination.Add(source[i]); }
                    yield return combination.ToArray();
                }
            }
        }
        [System.Diagnostics.DebuggerStepThrough]
        public static IEnumerable<T[]> EveryContiguousSubset<T>(this IEnumerable<T> enumerable)
        {
            yield return new T[] { };
            int length = enumerable.Count();
            for (int i = 0; i < length; i++)
            {
                for (int j = 1; j + i - 1 < length; j++)
                {
                    var subset = enumerable.Skip(i).Take(j);
                    yield return subset.ToArray();
                }
            }
        }
        [System.Diagnostics.DebuggerStepThrough] public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable) => new HashSet<T>(enumerable);
        [System.Diagnostics.DebuggerStepThrough] public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> comparer) => new HashSet<T>(enumerable, comparer);
        [System.Diagnostics.DebuggerStepThrough] public static HashSet<TOut> ToHashSet<TIn, TOut>(this IEnumerable<TIn> enumerable, Func<TIn, TOut> func) => new HashSet<TOut>(enumerable.Select(e => func(e)));
        [System.Diagnostics.DebuggerStepThrough] public static HashSet<TOut> ToHashSet<TIn, TOut>(this IEnumerable<TIn> enumerable, IEqualityComparer<TOut> comparer, Func<TIn, TOut> func) => new HashSet<TOut>(enumerable.Select(e => func(e)), comparer);
        [System.Diagnostics.DebuggerStepThrough] public static void Fill<T>(this T[] array, T value) => System.Threading.Tasks.Parallel.ForEach(Enumerable.Range(0, array.Length), n => array[n] = value);
        [System.Diagnostics.DebuggerStepThrough] public static bool IsNullOrEmpty<T>(this IEnumerable<T> array) => (array is null || !array.Any());
        // [System.Diagnostics.DebuggerStepThrough]
        public static IEnumerable<TOut> JoinOn<TIn, TOut>(this IEnumerable<TIn> a, IEnumerable<TIn> b, Func<TIn, TIn, bool> funcJoinOn, Func<TIn, TIn, TOut> funcOut)
            => a.Join(b, x => 0, x => 0, (x, y) => (x, y))
                .Where(p => funcJoinOn(p.x, p.y))
                .Select(o => funcOut(o.x, o.y));
    }
}