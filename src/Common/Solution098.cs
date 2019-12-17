using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution098
    {
        public static bool DoesTextExist(char[,] array, string text)
        {
            var textArray = text.ToCharArray();
            bool[,] mask = MaskFromArray(array);
            mask.Print(true);
            foreach (var letter in textArray)
            {
                var next = FindLetter(array, letter, false, 0, 0);
            }
            throw new NotImplementedException();
        }
        private static bool[,] MaskFromArray(char[,] array)
        {
            var xMax = array.GetUpperBound(0);
            var yMax = array.GetUpperBound(1);
            var places = Enumerable.Range(0, xMax).SelectMany(x => Enumerable.Range(0, yMax).Select(y => new { x, y })).ToArray();
            bool[,] mask = new bool[xMax, yMax];
            bool V = false;
            foreach (var item in places)
            {
                mask[item.x, item.y] = V;
            }
            return mask;
        }
        private static IEnumerable<(int x, int y)> FindLetter(char[,] array, char letter, bool adjacent = false, int x = 0, int y = 0, bool[,] mask = null)
        {
            yield break;
            if (mask == null)
            {
                ;
            }
        }
    }
}