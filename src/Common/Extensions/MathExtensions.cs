using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Common.Extensions
{
    public static class MathExtensions
    {
        private static double StandardDeviation(IEnumerable<double> numberSet, double divisor)
        {
            var set = numberSet.ToArray(); //make array so it doesn't re-enumerate.
            double mean = set.Average();
            return Math.Sqrt(set.Sum(x => Math.Pow(x - mean, 2)) / divisor);
        }
        public static double PopulationStandardDeviation(this IEnumerable<double> numberSet) => StandardDeviation(numberSet, numberSet.Count());
        public static double SampleStandardDeviation(this IEnumerable<double> numberSet) => StandardDeviation(numberSet, numberSet.Count() - 1);
        public static double PopulationStandardDeviation(this IEnumerable<int> numberSet) => StandardDeviation(numberSet.Select(n=>(double)n), numberSet.Count());
        public static double SampleStandardDeviation(this IEnumerable<int> numberSet) => StandardDeviation(numberSet.Select(n=>(double)n), numberSet.Count() - 1);
        public static bool[][] GenerateBitMasks(int n)
        {
            var bitmasks = Enumerable.Range(0, (int)Math.Pow(2, n)).ToArray();
            var bits = Enumerable.Range(0, n).Select(r => (int)Math.Pow(2, r)).ToArray();
            var series = bitmasks.Select(mask => bits.Select(bit => (bit & mask) == bit).ToArray()).ToArray();
            return series;
        }
    }
}