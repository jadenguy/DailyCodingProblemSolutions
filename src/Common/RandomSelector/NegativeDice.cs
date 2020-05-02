using System;
using System.Linq;

namespace Common.Test
{
    public class NegativeDice
    {
        private int max;
        private int[] nonFaces;
        private bool invert;
        private System.Random rand;
        public NegativeDice(int max, int[] nonFaces, int seed = 0)
        {
            this.max = max;
            rand = Rand.NewRandom(seed);
            this.nonFaces = Enumerable.Range(0, max).Intersect(nonFaces).ToArray();
            if (max == nonFaces.Length) { throw new Exception(); }
            double halfOfAll = max / 2d;
            int unavailable = this.nonFaces.Length;
            this.invert = halfOfAll < unavailable;
            if (invert) { this.nonFaces = Enumerable.Range(0, max).Except(nonFaces).ToArray(); }
        }
        public int Next()
        {
            int next;
            do { next = rand.Next(max); }
            while ((nonFaces.Contains(next) ^ invert));
            return next;
        }
    }
}