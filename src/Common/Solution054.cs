using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common.Test
{
    public class Solution054
    {
        public static bool ValidateSquare(string square)
        {
            if (square.Length != 9) { return false; }
            var valid = true;
            var numbers = new int[10];
            for (int i = 0; valid && i < 9; i++)
            {
                var number = int.Parse(square[i].ToString());
                for (int target = 1; valid && target <= 9; target++)
                // I don't care about 0 or blank
                {
                    if (number == target)
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
            var vrt = new List<int>[9];
            var hrz = new List<int>[9];
            var sqr = new List<int>[9];
            for (int h = 0; h < 3; h++)
            {
                for (int i = 0; i < 3; i++)
                {
                    var squareIndex = h * 3 + i;
                    vrt[squareIndex] = new List<int>(9);
                    hrz[squareIndex] = new List<int>(9);
                    sqr[squareIndex] = new List<int>(9);
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            int cellIndex = ((j * 3) + k);
                            int horizontal = cellIndex + (squareIndex * 9);
                            int vertical = (cellIndex) * 9 + squareIndex;
                            int box = (3 * j) + (k) + (i * 9) + h * 3; // this is giving me trouble

                            System.Diagnostics.Debug.WriteLine(squareIndex, "i");
                            System.Diagnostics.Debug.WriteLine(horizontal, "h");
                            System.Diagnostics.Debug.WriteLine(vertical, "v");
                            System.Diagnostics.Debug.WriteLine(box, "b");
                            System.Diagnostics.Debug.WriteLine("");

                            hrz[squareIndex].Add(horizontal);
                            vrt[squareIndex].Add(vertical);
                            sqr[squareIndex].Add(box);

                            ret[squareIndex] += board[horizontal];
                            ret[squareIndex + 9] += board[vertical];
                            ret[squareIndex + 18] += board[box];
                        }
                    }
                }

            }
            return ret;
        }
    }
}