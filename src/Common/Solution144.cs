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
                int upperIndex = index + delta;
                int lowerIndex = index - delta;
                bool upperBoundOK = array.Length > upperIndex;
                bool lowerBoundOk = 0 <= lowerIndex;
                if (upperBoundOK && array[upperIndex] > yardstick) { return upperIndex; }
                else if (lowerBoundOk && array[lowerIndex] > yardstick) { return lowerIndex; }
                else if (!(upperBoundOK | lowerBoundOk)) { return null; }
                delta++;
            }
        }
    }
}