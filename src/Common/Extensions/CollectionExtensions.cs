using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Common.Extensions
{

    public static class CollectionExtensions
    {
        [System.Diagnostics.DebuggerStepThrough] public static string Print<T>(this IEnumerable<T> enumerable, string seperator = "\n") => string.Join(seperator, enumerable);
        [System.Diagnostics.DebuggerStepThrough] public static IEnumerable<T> Random<T>(this IEnumerable<T> e, Random rand = null) => e.OrderBy(r => (rand ?? new Random()).Next());
        [System.Diagnostics.DebuggerStepThrough]
        public static IEnumerable<T> StreamSlowly<T>(this IEnumerable<T> e, int milliseconds)
        {
            foreach (var item in e)
            {
                Thread.Sleep(milliseconds);
                yield return item;
            }
        }
        public static IEnumerable<T[]> EverySubset<T>(this IEnumerable<T> enumerable)
        {
            var source = enumerable.ToArray();
            int length = source.Length;
            for (int i = 0; i < Math.Pow(2, length); i++)
            {
                T[] combination = new T[length];
                for (int j = 0; j < length; j++)
                {
                    int v = length - j - 1;
                    int v1 = 1 << v;
                    int v2 = (i & v1);
                    if (v2 != 0)
                    {
                        combination[j] = source[j];
                    }
                }
                yield return combination;
            }
        }
        public static IEnumerable<T[]> EveryPermutation<T>(this IEnumerable<T> enumerable) where T : IEquatable<T>
        {
            if (enumerable.Count() == 1) { yield return enumerable.ToArray(); }
            else
            {
                for (int i = 0; i < enumerable.Count(); i++)
                {
                    var x = new List<T>(enumerable);
                    x.RemoveAt(i);
                    foreach (var item in x.EveryPermutation())
                    {
                        yield return (new List<T>(item) { enumerable.ElementAt(i) }).ToArray();
                    }
                }
            }
        }
    }
}