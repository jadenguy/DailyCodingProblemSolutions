using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Extensions;

namespace Common
{
    public static class Solution054
    {
        public static string PrintBoard(this string board)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                sb.AppendLine(board.Substring(i * 9, 9));
            }
            System.Diagnostics.Debug.WriteLine(sb);
            return sb.ToString();
        }
        public static bool IsSquareSolved(string square)
        {
            bool valid;
            int[] numbers;
            valid = ValidateCells(square, out numbers);
            return valid && numbers.Sum() == 9;
        }
        public static bool ValidateSquare(string square)
        {
            if (square.Length != 9) { return false; }
            bool valid;
            int[] numbers;
            valid = ValidateCells(square, out numbers);
            return valid;
        }
        private static bool ValidateCells(string square, out int[] numbers)
        {
            var valid = true;
            numbers = new int[10];
            for (int i = 0; valid && i < 9; i++)
            {
                var digit = int.Parse(square[i].ToString());
                for (int target = 1; valid && digit != 0 && target <= 9; target++)
                // I don't care about 0 or blank
                {
                    if (digit == target)
                    {
                        numbers[target]++;
                        valid = numbers[target] <= 1;
                    }
                }
            }
            return valid;
        }
        public static bool ValidateBoard(string board)
        {
            var ret = true;
            foreach (var square in BoardToSquares(board))
            {
                ret &= ValidateSquare(square);
            }
            return ret;
        }
        public static string[] BoardToSquares(string board)
        {
            var ret = new string[27];
            var squares = DefineSquares();
            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    ret[i] += board[squares[i][j]];
                }
            }
            return ret;
        }
        public static int[][] FindNeighbors(int i)
        {
            var squares = Solution054.DefineSquares();
            return squares.Where(k => k.Contains(i)).ToArray();
        }

        // I figured out working this out that Sudoku is a 2D representation of a 3d problem, slices of a 3 x 3 x 3 cube. So I've encoded a 3d problem, displayed as a 2d board, as a 1d string.
        public static int[][] DefineSquares()
        {
            var ret = new int[27][];
            // trinary representations of 9 below, once for which group, one for which value per group
            // sBig is the significant square trit, and sSmall is the insignificant trit
            for (int squareIndex = 0; squareIndex < 9; squareIndex++)
            {
                ret[squareIndex] = new int[9];
                ret[squareIndex + 9] = new int[9];
                ret[squareIndex + 18] = new int[9];
                // see above about sBig and sSmall, but Cell index trit values
                for (int cellIndex = 0; cellIndex < 9; cellIndex++)
                {
                    int horizontal = cellIndex + (squareIndex * 9);
                    int vertical = (cellIndex * 9) + squareIndex;
                    // got it, could have used % instead of building it components of 9, but here we are
                    // basically using the same formula as the above but swap the big trit with the small
                    //  trit of the opposite one
                    var cBig = cellIndex / 3;
                    var cSmall = cellIndex % 3;
                    var sBig = squareIndex / 3;
                    var sSmall = squareIndex % 3;
                    int box = (cBig * 9) + (cSmall) + (sSmall * 3) + (sBig * 27);
                    ret[squareIndex][cellIndex] = horizontal;
                    ret[squareIndex + 9][cellIndex] = vertical;
                    ret[squareIndex + 18][cellIndex] = box;
                }
            }
            return ret;
        }
        public static bool IsBoardSolved(string board)
        {
            var ret = true;
            foreach (var square in BoardToSquares(board))
            {
                ret &= IsSquareSolved(square);
            }
            return ret;
        }
        public static IEnumerable<string> Solve(string initialBoard)
        {
            var board = initialBoard.Select(d => int.Parse(d.ToString()).ToString()[0]).ToArray();
            int i = 0;
            var height = 1;
            var dict = new Dictionary<int, char[]>();
            var done = false;
            while (!done)
            {
                char cellValue = board[i];
                if (!board.Contains('0'))
                {
                    yield return board.Print("");
                    done = true;
                }
                if (height > 10)
                {
                    done = true;
                }
                if (cellValue == '0')
                {
                    if (dict.ContainsKey(i))
                    {
                        height++;
                    }
                    else
                    {
                        dict.Add(i, SuggestNext(board.Print(""), i).ToArray());
                    }
                    var suggestions = dict[i];
                    if (suggestions.Length == 0)
                    {
                        done = true;
                    }
                    else if (suggestions.Length == 1)
                    {
                        board[i] = suggestions[0];
                        height = 1;
                        dict.Clear();
                    }
                    else if (suggestions.Length <= height)
                    {
                        foreach (var suggestion in suggestions)
                        {
                            board[i] = suggestion;
                            // var possibleBoard = Solve(board.Print(""));
                            // if (possibleBoard.Contains(0.ToString()))
                            // {
                            //     yield return board.Print("");
                            //     // dict.Clear();
                            //     done = true;
                            // }
                            board[i] = '0';
                        }
                    }
                    else if (!board.Contains('0'))
                    {
                        yield return board.Print("");
                        done = true;
                    }
                }
                i = (i + 1) % 81;
            }
        }
        private static IEnumerable<char> SuggestNext(string initialBoard, int i)
        {
            int[][] neighborIndex = FindNeighbors(i).ToArray();
            char[][] neighborValue = neighborIndex.Select(k => k.Select(r => initialBoard[r]).Distinct().ToArray()).ToArray();
            return Enumerable.Range(1, 9).Select(n => n).Select(x => x.ToString()[0]).Where(l => !neighborValue.Where(n => n.Contains(l)).Any());
        }
        // public static IEnumerable<string> SolveBackTracking(string initialBoard)
        // {
        //     var board = initialBoard.ToCharArray();
        //     for (int i = 0; i < 81; i++)
        //     {
        //         char v = board[i];
        //         while (v == '0')
        //         {
        //             char[] suggestions = SuggestNext(board.Print(""), i).ToArray();
        //             if (suggestions.Length == 0) { break; }
        //             foreach (var suggestion in suggestions)
        //             {
        //                 // string x = "";
        //                 // if (i > 0) { x += board.Substring(0, i); }
        //                 // x += suggestion;
        //                 // if (i < 80)
        //                 // {
        //                 //     int length = 81 - i - 1;
        //                 //     int startIndex = i + 1;
        //                 //     x += board.Substring(startIndex, length);
        //                 // }
        //                 board[i] = suggestion;
        //                 var possibleBoard = SolveBackTracking(board.Print(""));
        //                 if (possibleBoard.Contains(0.ToString()))
        //                 {
        //                     yield return board.Print("");
        //                 }
        //             }
        //         }
        //     }
        // }
    }
}