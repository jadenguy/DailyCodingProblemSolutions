using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution136
    {
        public struct ViewPort //: IEnumerable<bool>
        {
            public int XUpper { get; }
            public int XLower { get; }
            public int YLower { get; }
            public int YUpper { get; }
            public bool[,] Matrix { get; }
            public bool IsFullRectangle => Values().All(v => v);
            public bool IsEmpty => !Values().Any(v => v);
            public int Area => (1 + XUpper - XLower) * (1 + YUpper - YLower);
            public ViewPort(int xUpper, int xLower, int yLower, int yUpper, bool[,] matrix)
            {
                Matrix = matrix ?? throw new NullReferenceException();
                if (!(Matrix.GetUpperBound(0) >= xUpper
                    && xUpper >= xLower
                    && xLower >= 0
                    && Matrix.GetUpperBound(1) >= yUpper
                    && yUpper >= yLower
                    && yLower >= 0)
                ) { throw new IndexOutOfRangeException(); }
                XLower = xLower;
                XUpper = xUpper;
                YLower = yLower;
                YUpper = yUpper;
            }
            private bool[,] View()
            {
                var ret = new bool[XUpper - XLower + 1, YUpper - YLower + 1];
                Array.Copy(ret, Values().ToArray(), ret.Length);
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
            private static Func<bool, string> Pretty() => n => n ? "X" : "_";
            public string Print() => View().Print(Pretty());
            public override bool Equals(object obj)
                => obj is ViewPort port &&
                    XUpper == port.XUpper &&
                    XLower == port.XLower &&
                    YLower == port.YLower &&
                    YUpper == port.YUpper &&
                    EqualityComparer<bool[,]>.Default.Equals(Matrix, port.Matrix);
            public override int GetHashCode()
                => ($"{XUpper}{XLower}{YUpper}{YLower}{Matrix.GetHashCode()}").GetHashCode();
        }
        public static IEnumerable<ViewPort> Rectangles(bool[,] matrix)
        {
            var whole = new ViewPort(0, matrix.GetUpperBound(0), 0, matrix.GetUpperBound(1), matrix);
            if (whole.IsFullRectangle)
            {
                WriterExtension.WriteHost("Whole thing");
                yield return whole;
                yield break;
            }
            var stack = AddNextSuggestions(whole);
            while (stack.Any())
            {
                foreach (var coordinates in stack.Where(v => v.IsFullRectangle))
                {
                    yield return coordinates;
                }
                stack = stack.Concat(AddNextSuggestions(stack.Where(v => !v.IsFullRectangle).First()));
            }
        }
        private static IEnumerable<ViewPort> AddNextSuggestions(ViewPort viewPort)
        {
            if (viewPort.IsEmpty) { return null; }
            (var xLower, var xUpper, var yLower, var yUpper, var matrix) = (viewPort.XLower, viewPort.XUpper, viewPort.YLower, viewPort.YUpper, viewPort.Matrix);
            viewPort.Print().WriteHost($"Inside Of {xLower},{yLower} and {xUpper},{yUpper}");
            var bits = Enumerable.Range(0, 16).Select(b => ((b & 1) == 1, (b & 2) == 2, (b & 4) == 4, (b & 8) == 8));
            var g = bits.Select(b => new ViewPort(xLower + (b.Item1 ? 1 : 0), xUpper, yLower, yUpper, matrix));
            return g.ToArray();
        }
    }
}