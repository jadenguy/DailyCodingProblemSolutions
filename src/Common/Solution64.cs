using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Solution64
    {
        public static IEnumerable<int[,]> KnightToursEveryCell(int boardSize = 5)
        {
            var ret = new List<int[,]>();
            var board = BlankBoard(boardSize);
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    var startPosition = (x, y);
                    var results = KnightTourFrom((int[,])board.Clone(), startPosition, 1).ToArray();
                    ret.AddRange(results);
                }
            }
            return ret;
        }
        public static string PrintBoard(this int[,] board)
        {
            var sb = new StringBuilder();
            for (int x = 0; x <= board.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= board.GetUpperBound(1); y++)
                {
                    sb.Append($"{board[x, y],5}");
                }
                sb.AppendLine();
            }
            System.Diagnostics.Debug.WriteLine(sb.ToString());
            System.Console.WriteLine();
            System.Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
        public static IEnumerable<int[,]> KnightTourFrom(int[,] board, (int x, int y) startPosition, int placeInList)
        {
            board[startPosition.x, startPosition.y] = placeInList;
            if (placeInList == board.Length)
            {
                // System.Diagnostics.Debug.WriteLine(board.PrintBoard());
                // System.Diagnostics.Debug.WriteLine($"{placeInList} at {startPosition}");
                yield return board;
            }
            else
            {
                var nextMove = FindNextKnightMove(board, startPosition);
                foreach (var move in nextMove)
                {
                    foreach (var item in KnightTourFrom((int[,])board.Clone(), move, placeInList + 1))
                    {
                        yield return item;
                    }
                }
            }
        }

        public static int[,] SelectElements(int size)
        {
            int[,] board;
            bool odd = true;
            if (size % 2 == 0) { odd = false; }
            board = new int[size, size];
            for (int xPos = 0; xPos < size / 2; xPos++)
            {
                for (int yPos = xPos; yPos < size / 2; yPos++)
                {
                    var value = 8;
                    board[xPos, yPos] = -1;
                    if (xPos == yPos)
                    {
                        value = 4;
                        if (odd && xPos == 1 + (size / 2)) { value = 1; }
                    }
                    board[xPos, yPos] = value;
                }
            }
            return board;
        }
        private static IEnumerable<(int, int)> FindNextKnightMove(int[,] board, (int x, int y) position)
        {
            var xMax = board.GetUpperBound(0);
            var yMax = board.GetUpperBound(1);
            var pointList = new List<(int, int)>();

            int x = position.x;
            var xp1 = x < xMax;
            var xp2 = x < xMax - 1;
            var xn1 = x > 0;
            var xn2 = x > 1;

            int y = position.y;
            var yp1 = y < yMax;
            var yp2 = y < yMax - 1;
            var yn1 = y > 0;
            var yn2 = y > 1;

            if (xp1 && yp2) pointList.Add((x + 1, y + 2));
            if (xp1 && yn2) pointList.Add((x + 1, y - 2));
            if (xn1 && yp2) pointList.Add((x - 1, y + 2));
            if (xn1 && yn2) pointList.Add((x - 1, y - 2));

            if (xp2 && yp1) pointList.Add((x + 2, y + 1));
            if (xp2 && yn1) pointList.Add((x + 2, y - 1));
            if (xn2 && yp1) pointList.Add((x - 2, y + 1));
            if (xn2 && yn1) pointList.Add((x - 2, y - 1));

            foreach ((int x, int y) point in pointList)
            {
                if (board[point.x, point.y] == 0) { yield return point; }
            }
            
            // return pointList.Where(p=>board[p.Item1, p.Item2] == 0);

        }
        public static int[,] BlankBoard(int boardSize = 8)
        {
            var board = new int[boardSize, boardSize];
            return board;
        }
    }
}