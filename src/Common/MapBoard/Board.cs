using System;
using System.Collections.Generic;
using System.Text;

namespace Common.MapBoard
{
    public class Board
    {
        protected Cell[,] board;
        public (int, int) Start { get; set; }
        public (int, int) End { get; set; }
        public Board(bool[,] grid, (int, int) start, (int, int) end)
        {
            Start = start;
            End = end;
            int xLength = grid.GetLength(0);
            int yLength = grid.GetLength(1);
            board = new Cell[xLength, yLength];
            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    if (!grid[x, y])
                    {
                        board[x, y] = new Cell(x, y);
                        board[x, y].SetH(End);
                    }
                }
            }
        }
        public string Print()
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
                    if (cell == null)
                    {
                        ret.Append("X");
                    }
                    else
                    {
                        if (x == Start.Item1 && y == Start.Item2) { ret.Append("S"); }
                        else if (x == End.Item1 && y == End.Item2) { ret.Append("E"); }
                        else { ret.Append(" "); }
                    }
                }
                ret.AppendLine("|");
            }
            ret.Append(TopWallForPrint(xLength));
            return ret.ToString();
        }
        public static string TopWallForPrint(int xLength)
        {
            var ret = new StringBuilder();
            ret.Append("*");
            for (int x = 0; x < xLength; x++)
            {
                ret.Append("-");
            }
            ret.AppendLine("*");
            return ret.ToString();
        }
        public Cell this[(int, int) location]
        {
            get => board[location.Item1, location.Item2];
        }
        public Cell this[int x, int y]
        {
            get => board[x, y];
        }
        public IEnumerable<Cell> GetNeighbors(Cell current)
        {
            int x = current.X;
            int y = current.Y;
            int xMax = board.GetUpperBound(0);
            if (x > 0 && board[x - 1, y] != null) { yield return board[x - 1, y]; }
            if (x < xMax && board[x + 1, y] != null) { yield return board[x + 1, y]; }
            int yMax = board.GetUpperBound(1);
            if (y > 0 && board[x, y - 1] != null) { yield return board[x, y - 1]; }
            if (y < yMax && board[x, y + 1] != null) { yield return board[x, y + 1]; }
        }
    }
}