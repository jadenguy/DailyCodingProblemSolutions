using System;

namespace Common
{
    public static class Solution136
    {
        public static (int Value, int x0, int x1, int y0, int y1) LargestRectangle(bool[,] matrix)
        {
            int x0 = 0, x1 = 0, y0 = 0, y1 = 0;
            return ((x1 - x0) * (y1 - y0), x0, x1, y0, y1);
            throw new NotImplementedException();
        }
    }
}