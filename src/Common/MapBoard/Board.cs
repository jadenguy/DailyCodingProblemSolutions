using System.Text;

namespace Common.MapBoard
{
    public class Board
    {
        private Cell[,] board;
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
            ret.Append(TopWall(xLength));
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
                        else { ret.Append("0"); }
                    }
                }
                ret.AppendLine("|");
            }
            ret.Append(TopWall(xLength));
            return ret.ToString();
        }
        private static string TopWall(int xLength)
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
    }
}