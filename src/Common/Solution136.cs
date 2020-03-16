using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution136
    {
        public struct ViewPort : IEquatable<ViewPort>
        {
            public int XUpper { get; }
            public int XLower { get; }
            public int YLower { get; }
            public int YUpper { get; }
            public bool[,] Matrix { get; }
            public bool IsFullRectangle => Values().All(v => v);
            public bool IsEmpty => !Values().Any(v => v);
            public int Area => (1 + XUpper - XLower) * (1 + YUpper - YLower);
            public int Landmass => Values().Count(v => v);
            public ViewPort(int xLower, int xUpper, int yLower, int yUpper, bool[,] matrix)
            {
                Matrix = matrix ?? throw new NullReferenceException();
                if (!Validate(matrix, xLower, xUpper, yLower, yUpper)
                ) { throw new IndexOutOfRangeException(); }
                XLower = xLower;
                XUpper = xUpper;
                YLower = yLower;
                YUpper = yUpper;
            }
            public static bool Validate(bool[,] matrix, int xLower, int xUpper, int yLower, int yUpper)
                => (matrix != null &&
                    matrix.GetUpperBound(0) >= xUpper
                    && xUpper >= xLower
                    && xLower >= 0
                    && matrix.GetUpperBound(1) >= yUpper
                    && yUpper >= yLower
                    && yLower >= 0);
            public bool[,] View()
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
            public string Print() => View().Print(n => n ? "X" : "_");
            public override bool Equals(object obj)
                => obj is ViewPort port &&
                    port.Equals(this);
            public override int GetHashCode()
                => ($"{XUpper}{XLower}{YUpper}{YLower}{Matrix.GetHashCode()}").GetHashCode();
            public bool Equals(ViewPort other)
                => XUpper == other.XUpper &&
                    XLower == other.XLower &&
                    YLower == other.YLower &&
                    YUpper == other.YUpper &&
                    EqualityComparer<bool[,]>.Default.Equals(Matrix, other.Matrix);
        }
        public static IEnumerable<ViewPort> Rectangles(bool[,] matrix)
        {
            var whole = new ViewPort(0, matrix.GetUpperBound(0), 0, matrix.GetUpperBound(1), matrix);
            var stack = AddNextSuggestions(whole).ToList();
            for (int i = 0; i < stack.Count; i++)
            {
                ViewPort viewPort = stack[i];
                if (viewPort.IsFullRectangle) { yield return viewPort; }
                stack.AddRange(AddNextSuggestions(viewPort));
                stack = stack.Distinct().ToList();
            }
            stack.Count.WriteHost("ConsideredRectangles");
        }
        private static IEnumerable<ViewPort> AddNextSuggestions(ViewPort viewPort)
        {
            if (viewPort.IsEmpty) { return null; }
            (var xLower, var xUpper, var yLower, var yUpper, var matrix) =
                (viewPort.XLower, viewPort.XUpper, viewPort.YLower, viewPort.YUpper, viewPort.Matrix);
            // viewPort.Print().WriteHost($"Inside Of {xLower},{yLower} and {xUpper},{yUpper}");
            var stack = new List<ViewPort>();
            foreach (var bitmask in MathExtensions.GenerateBitMasks(4))
            {
                int xLowerNew = xLower + (bitmask[0] ? 1 : 0);
                int xUpperNew = xUpper - (bitmask[1] ? 1 : 0);
                int yLowerNew = yLower + (bitmask[2] ? 1 : 0);
                int yUpperNew = yUpper - (bitmask[3] ? 1 : 0);
                if (Solution136.ViewPort.Validate(matrix, xLowerNew, xUpperNew, yLowerNew, yUpperNew))
                { stack.Add(new ViewPort(xLowerNew, xUpperNew, yLowerNew, yUpperNew, matrix)); }
            }
            return stack.Where(v => !v.IsEmpty);
        }
    }
}