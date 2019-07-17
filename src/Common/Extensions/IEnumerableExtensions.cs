using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Common.Extensions
{

    public static class IEnumerableExtension
    {

        public static double CalculateStdDev(this IEnumerable<double> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                //Compute the Average      
                double avg = values.Average();
                //Perform the Sum of (value-avg)_2_2      
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                //Put it all together      
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }
        public static string Print<T>(this IEnumerable<T> enumerable, string seperator = "\n")
        {
            var ret = new StringBuilder();
            if (enumerable != null)
            {
                bool repeat = false;
                foreach (var item in enumerable)
                {
                    if (repeat) { ret.Append(seperator); }
                    repeat = true;
                    ret.Append(item.ToString());
                }
            }
            return ret.ToString();
        }
        public static IEnumerable<T> Random<T>(this IEnumerable<T> e, Random rand = null) => e.OrderBy(r => (rand ?? new Random()).Next());
        public static IEnumerable<T> StreamSlowly<T>(this IEnumerable<T> e, int milliseconds)
        {
            foreach (var item in e)
            {
                Thread.Sleep(milliseconds);
                yield return item;
            }
        }
        public static T RandomFirst<T>(this IEnumerable<T> e, Random rand = null) => e.Random().First();
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