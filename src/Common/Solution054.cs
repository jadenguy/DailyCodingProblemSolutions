using System;
using System.Linq;
using System.Text;

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
                    ret[i] += board[squares[i, j]];
                }
            }
            return ret;
        }
        // I figured out working this out that Sudoku is a 2D representation of a 3d problem, slices of a 3 x 3 x 3 cube. So I've encoded a 3d problem, displayed as a 2d board, as a 1d string.
        private static int[,] DefineSquares()
        {
            var ret = new int[27, 9];
            // trinary representations of 9 below, once for which group, one for which value per group
            // sBig is the significant square trit, and sSmall is the insignificant trit
            for (int sBig = 0; sBig < 3; sBig++)
            {
                for (int sSmall = 0; sSmall < 3; sSmall++)
                {
                    var squareIndex = sBig * 3 + sSmall;
                    // see above about sBig and sSmall, but Cell index trit values
                    for (int cBig = 0; cBig < 3; cBig++)
                    {
                        for (int cSmall = 0; cSmall < 3; cSmall++)
                        {
                            int cellIndex = ((cBig * 3) + cSmall);
                            int horizontal = cellIndex + (squareIndex * 9);
                            int vertical = (cellIndex * 9) + squareIndex;
                            // got it, could have used % instead of building it components of 9, but here we are
                            // basically using the same formula as the above but swap the big trit with the small
                            //  trit of the opposite one
                            int box = (cBig * 9) + (cSmall) + (sSmall * 3) + (sBig * 27);
                            ret[squareIndex, cellIndex] = horizontal;
                            ret[squareIndex + 9, cellIndex] = vertical;
                            ret[squareIndex + 18, cellIndex] = box;
                        }
                    }
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
    }
}