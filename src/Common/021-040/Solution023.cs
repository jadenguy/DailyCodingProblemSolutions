using System;
using Common.Board;

namespace Common
{
    public class Solution023

    {
        public static Cell[] AStarSearchStepCount(bool[,] grid, (int, int) start, (int, int) end)
        {
            Cell[] ret= new Cell[0];
            if (!grid[start.Item1, start.Item2] && !grid[end.Item1, end.Item2])
            {
                ret = new AStarMaze(grid, start, end).AStarPath();
            }
            return ret;
        }
    }
}