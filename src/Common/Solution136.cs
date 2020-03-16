using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution136
    {
        public class ViewPort
        {
            public int XUpper { get; }
            public int XLower { get; }
            public int YUpper { get; }
            public int YLower { get; }
            public bool[,] Matrix { get; }
            public ViewPort(int xUpper, int xLower, int yUpper, int yLower, bool[,] matrix)
            {
                if (matrix is null) { throw new NullReferenceException(); }
                if (!(matrix.GetUpperBound(0) >= xUpper
                    && xUpper >= xLower
                    && xLower >= 0
                    && matrix.GetUpperBound(1) >= yUpper
                    && yUpper >= yLower
                    && yLower >= 0)
                ) { throw new IndexOutOfRangeException(); }
                XUpper = xUpper;
                XLower = xLower;
                YUpper = yUpper;
                YLower = yLower;
                Matrix = matrix;
            }
            private bool[,] View()
            {
                var ret = new bool[XUpper - XLower + 1, YUpper - YLower + 1];
                for (int x = XLower; x <= XUpper; x++)
                {
                    for (int y = YLower; y <= YUpper; y++)
                    {
                        ret[x - XLower, y - YLower] = Matrix[x, y];
                    }
                }
                return ret;
            }
            public bool IsRectangle => Values().All(v => v);
            public bool IsEmpty => !Values().Any(v => v);
            private IEnumerable<bool> Values()
            {
                for (int x = XLower; x <= XUpper; x++)
                {
                    for (int y = YLower; y <= YUpper; y++)
                    {
                        yield return Matrix[x, y];
                    }
                }
            }
            private static Func<bool, string> pretty() => n => n ? "X" : "_";
            private bool Validate(bool[,] matrix, (int xLower, int xUpper, int yLower, int yUpper) coordinates)
            {
                return XUpper <= matrix.GetUpperBound(0);
            }
        }
        public static IEnumerable<ViewPort> Rectangles(bool[,] matrix)
        {
            var whole = new ViewPort(0, matrix.GetUpperBound(0), 0, matrix.GetUpperBound(1), matrix);
            if (whole.IsRectangle)
            {
                WriterExtension.WriteHost("Whole thing");
                yield return whole;
                yield break;
            }
            else
            {
                seedStack = new[] { whole };
            }
            var stack = AddNextSuggestions(matrix, seedStack);
            while (stack.Any())
            {
                foreach (var coordinates in stack.Where(v => v.Valid).Select(g => g.Coordinates))
                {
                    yield return coordinates;
                }
                stack = AddNextSuggestions(matrix, stack.Where(v => !v.Valid).Select(n => n.Coordinates).ToArray());
            }
        }
        private static IEnumerable<((int xLower, int xUpper, int yLower, int yUpper) Coordinates, bool Valid)> AddNextSuggestions(bool[,] matrix, IEnumerable<(int xLower, int xUpper, int yLower, int yUpper)> r)
        {
            if (!r.Any()) { return new ((int, int, int, int), bool)[0]; }
            var q = r.Take(0).ToList();
            q.Print().WriteHost();
            var p = r.First();
            (var xLower, var xUpper, var yLower, var yUpper) = p;
            matrix.View(p).Print(pretty()).WriteHost($"Inside Of {p.xLower},{p.yLower} and {p.xUpper},{p.yUpper}");
            if (matrix[xLower, yLower])
            {
                q.Add((xLower, xUpper, yLower, yUpper - 1));
                q.Add((xLower, xUpper - 1, yLower, yUpper));
                q.Add((xLower, xUpper - 1, yLower, yUpper - 1));
            }
            if (matrix[xUpper, yLower])
            {
                q.Add((xLower + 1, xUpper, yLower, yUpper));
                q.Add((xLower, xUpper, yLower, yUpper - 1));
                q.Add((xLower + 1, xUpper, yLower, yUpper - 1));
            }
            if (matrix[xUpper, yUpper])
            {
                q.Add((xLower + 1, xUpper, yLower, yUpper));
                q.Add((xLower, xUpper, yLower + 1, yUpper));
                q.Add((xLower + 1, xUpper, yLower + 1, yUpper));
            }
            if (matrix[xLower, yUpper])
            {
                q.Add((xLower, xUpper - 1, yLower, yUpper));
                q.Add((xLower, xUpper, yLower - 1, yUpper));
                q.Add((xLower, xUpper - 1, yLower + 1, yUpper));
            }
            q.Add((xLower + 1, xUpper - 1, yLower, yUpper));
            q.Add((xLower, xUpper, yLower + 1, yUpper - 1));
            q.Add((xLower + 1, xUpper - 1, yLower + 1, yUpper - 1));
            var next = q.Where(g =>
                    g.xLower >= 0 &&
                    g.xUpper >= 0 &&
                    g.yLower >= 0 &&
                    g.yUpper >= 0 &&
                    g.xLower <= g.xUpper &&
                    g.yLower <= g.yUpper
                ).ToArray();
            var enumerable = next.Concat(r.Skip(1));
            var summary = next.Select(g =>
                        new
                        {
                            LandMass = matrix.ConsiderArea(g).Count(f => f),
                            Area = (g.xUpper - g.xLower + 1) * (g.yUpper - g.yLower + 1),
                            Coordinates = g,
                            Valid = Validate(matrix, g)
                        }
                    );
            var ret = summary.Distinct()
                .Where(t => t.LandMass > 0 && (t.Valid || t.Area > 1))
                .OrderByDescending(g => g.Area)
                .ThenByDescending(t => t.LandMass)
                .ThenBy(x => x.Coordinates.xLower)
                .ThenBy(y => y.Coordinates.yLower)
                .ThenBy(x => x.Coordinates.xUpper)
                .ThenBy(y => y.Coordinates.yUpper); ;
            ret.Count().WriteHost("Remainder");
            return ret.Select(g => (g.Coordinates, g.Valid)).ToArray();
        }
    }
}