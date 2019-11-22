// Given an integer n and a list of integers l, write a function that randomly generates a number from 0 to n-1 that isn't in l (uniform).

using System;

namespace Common.Test
{
    public class NegativeDice
    {
        private int max;
        private int[] nonFaces;

        public NegativeDice(int max, int[] nonFaces)
        {
            this.max = max;
            this.nonFaces = nonFaces;
        }

        public int Next()
        {
            throw new NotImplementedException();
        }
    }
}