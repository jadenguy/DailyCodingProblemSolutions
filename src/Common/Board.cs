namespace Common
{
    public class Board
    {
        private Cell[,] board;
        private (int, int) start;
        private (int, int) end;
        public Board(bool[,] grid, (int, int) start, (int, int) end)
        {
            int xLength = grid.GetLength(0);
            int yLength = grid.GetLength(1);
            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    if (grid[x, y])
                    {
                        board[x, y] = new Cell(x, y);
                    }
                }
            }
        }
    }
}