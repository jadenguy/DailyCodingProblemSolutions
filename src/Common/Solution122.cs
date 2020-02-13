// You are given a 2-d matrix where each cell represents number of coins in that cell. Assuming we start at matrix[0][0], and can only move right or down, find the maximum number of coins you can collect by the bottom right corner.
// For example, in this matrix
// 0 3 1 1
// 2 0 0 4
// 1 5 3 1
// The most we can collect is 0 + 2 + 1 + 5 + 3 + 1 = 12 coins.

using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution122
    {
        private class Instruction : IEquatable<Instruction>
        {
            private bool isX = false;
            private static System.Random rand;
            private static object l = new object();
            private int hash;
            public int XDelta { get => IsX ? 1 : 0; }
            public int YDelta { get => IsX ? 0 : 1; }
            public Instruction(bool x) { IsX = x; }
            public bool IsX { get => isX; set => isX = value; }
            public int Hash
            {
                get
                {
                    lock (l)
                    {
                        rand = rand == null ? new System.Random() : rand;
                        while (hash == 0) { hash = rand.Next(); }
                    }
                    return hash;

                }
            }
            public override string ToString() => IsX ? "X" : "Y";
            public override int GetHashCode()
            {
                return Hash;
            }

            public bool Equals(Instruction other) => other.Hash == Hash;
        }
        public static int BestPathScoreNaive(int[,] input)
        {
            var x = Enumerable.Range(0, input.GetUpperBound(0)).Select(n => m(true));
            var y = Enumerable.Range(0, input.GetUpperBound(1)).Select(n => m(false));
            var all = y.Union(x).EveryPermutation();
            var v = all.Max(s => Score(input, s));
            return v;
        }
        private static Instruction m(bool isX) => new Instruction(isX);
        private static int Score(int[,] input, IEnumerable<Instruction> instructions)
        {
            (int x, int y) start = (0, 0);
            var ret = 0;
            ret += input[start.x, start.y];
            foreach (var step in instructions)
            {
                start = start.Apply(step);
                ret += input[start.x, start.y];
            }
            return ret;
        }
        private static (int, int) Apply(this (int, int) a, Instruction b) => (a.Item1 + b.XDelta, a.Item2 + b.YDelta);
    }
}