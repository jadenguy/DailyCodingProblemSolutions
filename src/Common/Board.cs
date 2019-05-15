using System.Text;

namespace Common
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
                    if (grid[x, y])
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
            board = new Cell[xLength, yLength];
            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    if (board[x, y] == null)
                    {
                        ret.Append("X");
                    }
                    else
                    {
                        ret.Append(" ");
                    }
                }
                ret.AppendLine();
            }
            return ret.ToString();
        }
    }
}