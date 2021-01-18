using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public class Solution150
    {
        public static IEnumerable<(int, int)> FindKClosestPoints(IEnumerable<(int x, int y)> points, int k)
        {
            return points.Shuffle().OrderBy(v => (v.x * v.x) + (v.y * v.y)).Take(k);
        }
    }
}