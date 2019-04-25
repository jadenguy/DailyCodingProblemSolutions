using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution21
    {
        public static int MaxConcurrent((int, int)[] rangeArray)
        {
            var timeline = new SortedList<int, int>();
            foreach (var range in rangeArray)
            {
                var start = range.Item1;
                var end = range.Item2;
                timeline.Add(start, 0);
                timeline.Add(end, 0);
            }
            foreach (var range in rangeArray)
            {
                var start = range.Item1;
                var end = range.Item2;
                var affectedTimes = timeline.Keys.Where(e => e >= start && e <= end).ToList();
                for (int i = 0; i < affectedTimes.Count; i++)
                {
                    int time = affectedTimes[i];
                    timeline[time]++;
                }
            }
            return timeline.Values.Max();
        }
    }
}