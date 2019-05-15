using System;

namespace Common
{
    public class Solution23
    {
        public static int AStarSearchStepCount(bool[,] grid, (int, int) start, (int, int) end)
        {
            var ret = 0;
            if (!grid[start.Item1, start.Item2] && !grid[end.Item1, end.Item2])
            {
                var x = new Board(grid, start, end);
                System.Diagnostics.Debug.WriteLine(x.Print());
            }
            return ret;
        }
    }
}