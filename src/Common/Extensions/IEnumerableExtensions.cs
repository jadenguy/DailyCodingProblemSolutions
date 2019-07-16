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
        public static string Print<T>(this IEnumerable<T> enumerable)
        {
            var ret = new StringBuilder();
            if (enumerable != null)
            {
                foreach (var item in enumerable)
                {
                    ret.AppendLine(item.ToString());
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
        public static T RandomFirst<T>(this IEnumerable<T> e, Random rand = null) => e.OrderBy(r => (rand ?? new Random()).Next()).First();
    }
}