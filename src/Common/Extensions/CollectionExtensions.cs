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
        [System.Diagnostics.DebuggerStepThrough]
        public static string Print<T>(this IEnumerable<T> enumerable, string seperator = "\n", Func<T, object> func = null)
        {
            if (func is null) { func = v => v.ToString(); }
            return string.Join(seperator, enumerable.Select(v => func(v)));
        }
        public static string Print<T>(this T[,] enumerable, Func<T, object> func = null)
        {
            if (func is null) { func = o => o; }
            var sb = new System.Text.StringBuilder();
            int maxX = enumerable.GetUpperBound(0);
            int maxY = enumerable.GetUpperBound(1);
            var width = 1 + (enumerable.Cast<T>()).Select(n => func(n)).Max(t => t.ToString().Length);
            for (int x = 0; x <= maxX; x++)
            {
                sb.AppendLine();
                for (int y = 0; y <= maxY; y++)
                {
                    var current = func(enumerable[x, y]);
                    sb.Append(new string(' ', width - current.ToString().Length));
                    sb.Append(current.ToString());
                }
            }
            return sb.ToString();
        }
        [System.Diagnostics.DebuggerStepThrough] public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> e, Random rand = null) => e.OrderBy(r => (rand ?? new Random()).Next());
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
        public static IEnumerable<T[]> EveryPermutation<T>(this IEnumerable<T> enumerable)
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