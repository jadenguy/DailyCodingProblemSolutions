using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class Solution064

    {
        public static List<int[,]> KnightToursEveryCell(int boardSize = 5)
        {
            var ret = new List<int[,]>();
            var board = BlankBoard(boardSize);
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    ret.AddRange(KnightTourFrom((int[,])board.Clone(), (x, y), 1));
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
        public static int[,] SelectElements(int width, int height)
        {
            int[,] board = new int[width, height];
            int halfWidth = board.GetUpperBound(0);
            int halfHeight = board.GetUpperBound(1);
            for (int x = width - 1; x >= 0; x--)
            {
                for (int y = height - 1; y >= 0; y--)
                {
                    board[x, y]++;
                    var flipX = width - x - 1;
                    var flipY = height - y - 1;
                    TryStealValue(board, x, y, flipX, y);
                    TryStealValue(board, x, y, x, flipY);
                    TryStealValue(board, x, y, flipX, flipY);
                }
            }
            if (width == height)
            {
                for (int x = 0; x < halfWidth; x++)
                {
                    for (int y = x; y < halfHeight; y++)
                    {
                        var switchX = y;
                        var switchY = x;
                        TryStealValue(board, x, y, switchX, switchY);
                    }
                }
            }
            return board;
        }

        public static int KnightToursEveryCellCountOnly(int boardSize)
        {
            var ret = 0;
            var board = BlankBoard(boardSize);
            var multiplier = SelectElements(boardSize, boardSize);
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    int countMultiplier = multiplier[x, y];
                    if (countMultiplier > 0)
                    {
                        var results = KnightTourFrom((int[,])board.Clone(), (x, y), 1);
                        ret += (results.Count() * countMultiplier);
                    }
                }
            }
            return ret;
        }

        private static bool TryStealValue(int[,] board, int newX, int newY, int oldX, int oldY)
        {
            var ret = false;
            // try
            // {
            int value = board[oldX, oldY];
            board[newX, newY] += value;
            board[oldX, oldY] -= value;
            ret = true;
            // }
            // catch (System.Exception)
            // {
            // throw;
            // System.Diagnostics.Debug.WriteLine("exception!");
            // }
            return ret;
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

            // foreach ((int x, int y) point in pointList)
            // {
            //     if (board[point.x, point.y] == 0) { yield return point; }
            // }

            return pointList.Where(p => board[p.Item1, p.Item2] == 0);

        }
        public static int[,] BlankBoard(int boardSize = 8)
        {
            var board = new int[boardSize, boardSize];
            return board;
        }
    }
}