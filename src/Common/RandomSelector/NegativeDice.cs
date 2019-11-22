// Given an integer n and a list of integers l, write a function that randomly generates a number from 0 to n-1 that isn't in l (uniform).

using System;
using System.Linq;

namespace Common.Test
{
    public class NegativeDice
    {
        private int max;
        private int[] nonFaces;
        private bool timeSaver;
        private Random rand;
        public NegativeDice(int max, int[] nonFaces, int seed = 0)
        {
            this.max = max;
            if (seed == 0) { rand = new Random(); } else { rand = new Random(seed); }
            this.nonFaces = nonFaces;
            this.timeSaver = max / 2 > nonFaces.Length;
            if (timeSaver)
            {
                Enumerable.Range(0, max).Except(nonFaces);
            }
        }
        public int Next()
        {
            int next;
            do
            {
                next = rand.Next(max);
            }
            while (!(nonFaces.Contains(max) ^ timeSaver));
            return next;
        }
    }
}