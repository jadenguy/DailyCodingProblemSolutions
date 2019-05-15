using System;

namespace Common.MapBoard
{
    public class Cell
    {
        public int X;
        public int Y;
        public int F { get => G + H; }
        public int G { get => (Parent?.G ?? -1) + 1; }
        public int H { get => h; private set => h = value; }
        private int h;
        public Cell Parent;
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Cell(int x, int y, (int, int) target)
        {
            X = x;
            Y = y;
            SetH(target);
        }
        public void SetH((int, int) target)
        {
            h = Math.Abs(X - target.Item1) + Math.Abs(Y - target.Item2);
        }
        public override string ToString() => $"({X,2} , {Y,2})";
    }
}