using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Node;

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
            public override int GetHashCode() => Hash;
            public bool Equals(Instruction other) => other.Hash == Hash;
        }
        public static int BestPathScore(int[,] input)
        {
            if (input.Length < 1) { return 0; }
            int xLen = input.GetUpperBound(0) + 1;
            int yLen = input.GetUpperBound(1) + 1;
            var nodes = new GraphNode<int>[xLen, yLen];
            var start = new GraphNode<int>(0, "Start");
            var end = new GraphNode<int>(0, "End");
            for (int x = 0; x < xLen; x++)
            {
                for (int y = 0; y < yLen; y++)
                {
                    int value = -input[x, y];
                    nodes[x, y] = new GraphNode<int>(value, $"{x},{y}");
                    var current = nodes[x, y];
                    if (y > 0)
                    {
                        nodes[x, y - 1].ConnectTo(current, value);
                    }
                    if (x > 0)
                    {
                        nodes[x - 1, y].ConnectTo(current, value);
                    }
                }
            }
            start.ConnectTo(nodes[0, 0], -input[0, 0]);
            nodes[xLen - 1, yLen - 1].ConnectTo(end,0);
            var distances = start.BellmanFord();
            var ret = -Convert.ToInt32(distances[end]);
            return ret;
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