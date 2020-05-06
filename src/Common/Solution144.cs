using System;

namespace Common
{
    public static class Solution144
    {
        public static int? FindNearestLargeNumberIndexDelta(int[] array, int index)
        {
            var yardstick = array[index];
            var delta = 1;
            while (true)
            {
                int v = index + delta;
                int v1 = index - delta;
                int length = array.Length;
                bool v2 = length > v;
                bool v3 = 0 <= v1;
                if (v2 && array[v] > yardstick) { return v; }
                else if (v3 && array[v1] > yardstick) { return v1; }
                else if (!(v2 | v3)) { return null; }
                delta++;
            }
        }
    }
}