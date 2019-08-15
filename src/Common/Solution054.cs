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
        public static IEnumerable<string> BoardToSquares(string board)
        {
            var vrt = new List<int>[9];
            var hrz = new List<int>[9];
            var sqr = new List<int>[9];
            for (int i = 0; i < 9; i++)
            {
                vrt[i] = new List<int>(Enumerable.Range(i * 9, 9));
                hrz[i] = new List<int>(Enumerable.Range(i * 9, 9));
                sqr[i] = new List<int>(Enumerable.Range(i * 9, 9));
            }
        }
    }
}