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
        public static bool ValidateBoard(string square)
        {
            throw new NotImplementedException();
        }
        public static IEnumerable<string> BoardToSquares(string square)
        {
            for (int i = 0; i < 9; i++)
            {
                yield return square.Substring(i * 9, 9);// this is vertical
                System.Diagnostics.Debug.WriteLine(Enumerable.Range(i*9,9).Print(","));
            }
        }
    }
}