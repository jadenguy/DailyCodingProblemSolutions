
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public class Solution077
    {
        static Func<(int start, int end), (int start, int end), bool> isOverlap = (a, b) => b.end > a.start && a.end > b.start;
        public static (int, int)[] MergedOverlapping((int start, int end)[] array)
        {
            if (array.IsNullOrEmpty()) { throw new NullReferenceException("Array empty or null"); }
            var sortedArray = new Queue<(int start, int end)>(array.OrderBy(element => element.start));
            var ret = new Queue<(int start, int end)>();
            int max = int.MinValue;
            while (sortedArray.TryPeek(out var pair))
            {
                sortedArray.Dequeue();
                if (pair.start > max)
                {
                    if (sortedArray.Count > 0 && sortedArray.Where(other => isOverlap(pair, other)).Any())
                    {
                        pair.end = sortedArray.Where(other => isOverlap(pair, other)).Max(element => element.end);
                    }
                    ret.Enqueue(pair);
                }
                max = Math.Max(max, pair.end);
            }
            return ret.ToArray();
        }
    }
}