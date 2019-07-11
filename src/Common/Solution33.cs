using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Solution33
    {
        public static IEnumerable<double> StreamMedian(IEnumerable<double> stream)
        {
            var runningList = new List<double>();
            foreach (var element in stream)
            {
                runningList.Add(element);
                yield return runningList.Median();
            }
        }
        public static double Median(this IEnumerable<double> list)
        {
            var array = list.OrderBy(k => k).ToArray();
            var x = array.GetUpperBound(0) ;
            if (x % 2 == 0) { return array[x/2]; }
            else { return (array[x/2] + array[x/2+1]) / 2.0 ;}

        }
    }
}