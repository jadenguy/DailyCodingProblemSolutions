using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution136
    {
        public static IEnumerable<(int x0, int x1, int y0, int y1)> LargestRectangle(bool[,] matrix)
        {
            var q = new Queue<(int x0, int x1, int y0, int y1)>() { };
            q.Enqueue((0, matrix.GetUpperBound(0), 0, matrix.GetUpperBound(1)));
            while (q.Any())
            {
                (var x0, var x1, var y0, var y1) = q.Dequeue();
                if (x0 <= x1 || y0 <= y1)
                {
                    matrix.View(x0, x1, y0, y1).Print(n => n ? "X" : "_").WriteHost();
                    if (Validate(matrix, x0, x1, y0, y1)) { yield return (x0, x1, y0, y1); }
                    var topLeft00 = matrix[x0, y0];
                    var topRight10 = matrix[x1, y0];
                    var bottomLeft01 = matrix[x0, y1];
                    var bottomRight11 = matrix[x1, y1];


                    if (topLeft00 && !bottomRight11)
                    {
                        if (topRight10) { q.Enqueue((x0, x1, y0, y1 - 1)); }
                        if (bottomLeft01) { q.Enqueue((x0, x1 - 1, y0, y1)); }
                        if (!topRight10 && !bottomLeft01) { q.Enqueue((x0, x1 - 1, y0, y1 - 1)); }
                    }
                    if (!topLeft00 && bottomRight11)
                    {
                        if (topRight10) { q.Enqueue((x0 + 1, x1, y0, y1)); }
                        if (bottomLeft01) q.Enqueue((x0, x1, y0 + 1, y1));
                        if (!topRight10 && !bottomLeft01) { q.Enqueue((x0 + 1, x1, y0 + 1, y1)); }
                    }
                    if (topRight10 && !bottomLeft01)
                    {
                        if (topLeft00) { q.Enqueue((x0, x1 - 1, y0, y1)); }
                        if (bottomRight11) q.Enqueue((x0, x1, y0, y1 - 1));
                        if (!topLeft00 && bottomRight11) { q.Enqueue((x0, x1 - 1, y0, y1 - 1)); }
                    }
                    if (!topRight10 && bottomLeft01)
                    {
                        if (topLeft00) { q.Enqueue((x0, x1 - 1, y0, y1)); }
                        if (bottomRight11) q.Enqueue((x0, x1, y0, y1 - 1));
                    }


                    if (!topLeft00 || !bottomRight11 || !topRight10 || !bottomLeft01)
                    {
                        q.Enqueue((x0 + 1, x1 - 1, y0 + 1, y1 - 1));
                    }
                }
            }
        }
        private static bool Validate(bool[,] matrix, int x0, int x1, int y0, int y1)
            => ConsiderArea(matrix, x0, x1, y0, y1).All(n => n);
        private static IEnumerable<bool> ConsiderArea(bool[,] matrix, int x0, int x1, int y0, int y1)
        {
            for (int x = x0; x <= x1; x++)
            {
                for (int y = y0; y <= y1; y++)
                {
                    yield return matrix[x, y];
                }
            }
        }
        private static bool[,] View(this bool[,] matrix, int x0, int x1, int y0, int y1)
        {
            var ret = new bool[x1 - x0 + 1, y1 - y0 + 1];
            for (int x = x0; x <= x1; x++)
            {
                for (int y = y0; y <= y1; y++)
                {
                    ret[x - x0, y - y0] = matrix[x, y];
                }
            }
            return ret;
        }
    }
}