using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution150
    {
        public static IEnumerable<(int, int)> FindKClosestPoints((int x, int y)[] points, int k)
        {
            return points.OrderBy(v => (v.x * v.x)+(v.y * v.y)).Take(k);
        }
    }
}