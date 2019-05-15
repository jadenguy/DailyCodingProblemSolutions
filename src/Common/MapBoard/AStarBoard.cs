using System;
using System.Collections.Generic;

namespace Common.MapBoard
{
    public class AStarBoard : Board
    {
        private bool[,] searcheableSpace;
        public AStarBoard(bool[,] grid, (int, int) start, (int, int) end) : base(grid, start, end)
        {
            searcheableSpace = grid;
        }
        public Cell[] AStarPath()
        {
            var ret = new List<Cell>();
            var searchList = new SortedList<int, Cell>();
            var current = this[Start];
            var goal = this[End];
            searchList.AddCell(current);
            searcheableSpace[current.X, current.Y] = false;
            while (current != goal && searchList.Count > 0)
            {
                current = searchList.TakeTop();
                foreach (var neighbor in GetNeighbors(current))
                {
                    searchList.Add(neighbor.F, neighbor);
                }
            }
            if (current == goal)
            {
                ret.Add(current);
                current = current.Parent;
            }
            return ret.ToArray();
        }
    }
}