using System;
using System.Collections.Generic;

namespace Common
{
    public static class Solution9
    {
        private class Candidate
        {

            protected Candidate(int value, int[] path)
            {
                this.Value = value;
                this.Path = path;

            }
            public int Value { get; private set; }
            public int[] Path { get; private set; }

            public override string ToString()
            {
                return $"{Value} at {Path}";
            }
        }
        public static int LargestSumNonAdjacent(int[] list)
        {
            var ret = 0;
            var candidates = new Stack<Candidate>();
            foreach (var item in list)
            {
                
            }
            return ret;
        }
    }
}
