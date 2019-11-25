// Given an integer n and a list of integers l, write a function that randomly generates a number from 0 to n-1 that isn't in l (uniform).

using System;
using System.Linq;

namespace Common.Test
{
    public class NegativeDice
    {
        private int max;
        private int[] nonFaces;
        private bool invert;
        private Random rand;
        public NegativeDice(int max, int[] nonFaces, int seed = 0)
        {
            this.max = max;
            if (seed == 0) { rand = new Random(); } else { rand = new Random(seed); }
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