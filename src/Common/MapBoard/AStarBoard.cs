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
            var searchList = new List<Cell>();
            var current = this[Start];
            var goal = this[End];
            searchList.AddCell(current);
            searcheableSpace[current.X, current.Y] = false;
            while (current != goal && searchList.Count > 0)
            {
                current = searchList.TakeTopCell();
                foreach (var neighbor in GetNeighbors(current))
                {
                    if (searcheableSpace[current.X, current.Y])
                    {
                        neighbor.Parent = current;
                        searchList.AddCell(neighbor);
                    }
                }
            }
            if (current == goal)
            {
                while (current != null)
                {
                    ret.Add(current);
                    current = current.Parent;
                }
            }
            return ret.ToArray();
        }
    }
}