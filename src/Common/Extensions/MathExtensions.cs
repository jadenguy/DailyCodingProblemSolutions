using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Extensions
{
    public static class MathExtensions
    {
        private static double StandardDeviation(IEnumerable<double> numberSet, double divisor)
        {
            double mean = numberSet.Average();
            return Math.Sqrt(numberSet.Sum(x => Math.Pow(x - mean, 2)) / divisor);
        }

        public static double PopulationStandardDeviation(this IEnumerable<double> numberSet)
        {
            return StandardDeviation(numberSet, numberSet.Count());
        }

        public static double SampleStandardDeviation(this IEnumerable<double> numberSet)
        {
            return StandardDeviation(numberSet, numberSet.Count() - 1);
        }
    }
}