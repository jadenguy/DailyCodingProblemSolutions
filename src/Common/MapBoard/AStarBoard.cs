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
        public List<Cell> AStarPath()
        {
            var ret = new List<Cell>();
            var searchList = new List<Cell>();
            var current = this[Start];
            var goal = this[End];
            searchList.Add(current);


            return ret;
        }
    }
}