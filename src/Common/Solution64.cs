using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common
{
    public static class Solution64
    {
        public static int[][,] KnightTours(int boardSize = 8)
        {
            var ret = new List<int[,]>();
            var board = BlankBoard(boardSize);
            // for (int x = 0; x < boardSize; x++)
            // {
            // for (int y = 0; y < boardSize; y++)
            // {
            var startPosition = (2, 2);
            var nextMove = FindNextKnightMove(board, startPosition);
            System.Diagnostics.Debug.WriteLine(new { startPosition, moves = nextMove.Count() });
            // }
            // }
            return ret.ToArray();
        }
        private static IEnumerable<(int, int)> FindNextKnightMove(int[,] board, (int x, int y) p)
        {
            var xMax = board.GetUpperBound(0);
            var yMax = board.GetUpperBound(1);
            var pointList = new List<(int, int)>();

            int x = p.x;
            var xp1 = x < xMax;
            var xp2 = x < xMax - 1;
            var xn1 = x > 0;
            var xn2 = x > 1;

            int y = p.y;
            var yp1 = y < yMax;
            var yp2 = y < yMax - 1;
            var yn1 = y > 0;
            var yn2 = y > 1;

            if (xp1 && yn2) pointList.Add((x + 1, y - 2));
            if (xp1 && yp2) pointList.Add((x + 1, y + 2));
            if (xn1 && yp2) pointList.Add((x - 1, y + 2));
            if (xn1 && yn2) pointList.Add((x - 1, y - 2));

            if (xp2 && yn1) pointList.Add((x + 2, y - 1));
            if (xp2 && yp1) pointList.Add((x + 2, y + 1));
            if (xn2 && yp1) pointList.Add((x - 2, y + 1));
            if (xn2 && yn1) pointList.Add((x - 2, y - 1));

            foreach ((int x, int y) item in pointList)
            {
                if (board[item.x, item.y] == 0) { yield return (item.x, item.y); }
            }

        }
        private static int[,] BlankBoard(int boardSize = 8)
        {
            var board = new int[boardSize, boardSize];
            return board;
        }
    }
}