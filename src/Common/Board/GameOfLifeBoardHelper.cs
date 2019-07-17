using System.Collections.Generic;

namespace Common.Board
{
    public static class GameOfLifeBoardHelper
    {
        public static IEnumerable<(int, int)> GetNeighbors(this GameOfLifeBoard board, int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (!(i == 0 && j == 0) && board.Contains((i + x, j + y)))
                    {
                        yield return (i + x, j + y);
                    }
                }
            }
        }
        public static IEnumerable<(int, int)> GetNeighbors(this GameOfLifeBoard board, (int x, int y) cell) => GetNeighbors(board, cell.x, cell.y);
    }
}