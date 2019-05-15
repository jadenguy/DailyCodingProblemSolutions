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
            var win = false;
            searchList.Add(current.F, current);
            while (current != goal && searchList.Count > 0)
            {
                current = goal;
            }
            if (win)
            {
                ret.Add(current);
                current = current.Parent;
            }
            return ret.ToArray();
        }
    }
}