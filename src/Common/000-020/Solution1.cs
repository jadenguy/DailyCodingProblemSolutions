using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Solution1
    {
        public static object PairSumsContainComplex(int[] list, int wanted)
        {
            var even = false;
            var ret = false;
            var half = wanted / 2f;
            if (wanted % 2 == 0)
            {
                even = true;
            }
            var lesser = new List<int>();
            var greater = new List<int>();
            var exactlyHalfCount = 0;
            System.Diagnostics.Debug.WriteLine(half);
            var i = 0;
            while (i < list.Length)
            {
                int value = list[i];
                if (even && value / 2f == half)
                {
                    exactlyHalfCount++;
                    if (exactlyHalfCount == 2) { return true; }
                }
                else if (value < half && !lesser.Contains(value))
                {
                    int j = 0;
                    while (j < greater.Count)
                    {
                        var great = greater[j];
                        if (value + great == wanted)
                        {
                            ret = true;
                            j = greater.Count;
                        }
                        j++;
                    }
                    lesser.Add(value);
                }
                else
                {

                    foreach (var less in lesser)
                    {
                        ret = (value + less == wanted);
                    }
                    greater.Add(value);
                }
                i++;
            }
            return ret;
        }

        public static bool PairSumsContain(int[] list, int wanted)
        {
            var ret = false;
            var candidates = new SortedList<int, int>();
            foreach (var n in list)
            {
                if (n < wanted)
                {
                    var i = 0;
                    while (i < candidates.Count && candidates.Values.ElementAtOrDefault(i) + n < wanted)
                    {
                        i++;
                    }
                    var x = candidates.Values.ElementAtOrDefault(i);
                    if (x + n == wanted) { ret = true; break; }
                    candidates.Add(n, n);
                }
            }
            return ret;
        }
    }
}