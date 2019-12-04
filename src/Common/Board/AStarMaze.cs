using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Board
{
    public class AStarMaze : Maze
    {
        private bool[,] searcheableSpace;
        public AStarMaze(bool[,] grid, (int, int) start, (int, int) end) : base(grid, start, end)
        {
            searcheableSpace = grid;
        }
        public Cell[] AStarPath()
        {
            var ret = new List<Cell>();
            var searchList = new List<Cell>();
            var current = this[Start];
            var goal = this[End];
            AddCell(searchList, current);
            while (current != goal && searchList.Count > 0)
            {
                current = TakeTopCell(searchList);
                foreach (var neighbor in GetNeighbors(current))
                {
                    if (neighbor != null && !searcheableSpace[neighbor.X, neighbor.Y])
                    {
                        neighbor.Parent = current;
                        AddCell(searchList, neighbor);
                    }
                }
            }
            if (current == goal)
            {
                while (current != null)
                {
                    ret.Insert(0, current);
                    current = current.Parent;
                }
            }
            System.Diagnostics.Debug.WriteLine(Print(ret));
            return ret.ToArray();
        }

        private string Print(List<Cell> path)
        {
            var ret = new StringBuilder();
            int xLength = board.GetLength(0);
            int yLength = board.GetLength(1);
            ret.Append(TopWallForPrint(xLength));
            for (int x = 0; x < xLength; x++)
            {
                ret.Append("|");
                for (int y = 0; y < yLength; y++)
                {
                    Cell cell = board[x, y];
                    if (cell is null)
                    {
                        ret.Append("X");
                    }
                    else
                    {
                        if (x == End.Item1 && y == End.Item2 && x == Start.Item1 && y == Start.Item2) { ret.Append("="); }
                        else if (x == End.Item1 && y == End.Item2) { ret.Append("E"); }
                        else if (x == Start.Item1 && y == Start.Item2) { ret.Append("S"); }
                        else if (path.Contains(cell)) { ret.Append("-"); }
                        else if (searcheableSpace[cell.X, cell.Y]) { ret.Append("."); }
                        else { ret.Append("_"); }
                    }
                }
                ret.AppendLine("|");
            }
            ret.Append(TopWallForPrint(xLength));
            return ret.ToString();
        }

        public Cell TakeTopCell(List<Cell> list)
        {
            list.Sort((x, y) => x.F.CompareTo(y.F));
            var first = list[0];
            list.RemoveAt(0);
            return first;
        }
        public void AddCell(List<Cell> list, Cell cell)
        {
            searcheableSpace[cell.X, cell.Y] = !searcheableSpace[cell.X, cell.Y];
            // System.Diagnostics.Debug.WriteLine(Print());
            list.Add(cell);
        }
    }
}