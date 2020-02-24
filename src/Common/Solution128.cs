using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public static class Solution128
    {
        private static void WriteHost(this object o) => System.Diagnostics.Debug.WriteLine(o);
        public static (int from, int to)[] SolveTowerOfHanoi(int height)
        {
            var ret = new List<(int, int)>();
            var t = new HanoiPuzzle(height);
            string.Empty.WriteHost();
            ("Starting").WriteHost();
            (int, int)[] p = SolveForPlace(height - 1, 0, 2);
            ("Done").WriteHost();
            string.Empty.WriteHost();
            return p;
        }
        private static (int, int)[] SolveForPlace(int height, int from, int to)
        {
            if (height < 0) { return new (int, int)[0]; }
            var other = (new int[] { 0, 1, 2 }).Where(n => n != from && n != to).FirstOrDefault();
            var ret = new List<(int, int)>();
            Func<int, string> diskName = n => $"{(char)(n + 65)}-{n}";
            var wanted = diskName(height);
            var needed = diskName(height - 1);
            ($"\tI wish to move {wanted} from {from} to {to}").WriteHost();
            if (height > 0) { ($"\t\tTo move {wanted} from {from} to {to} I need to move {needed} from {from} to {other}").WriteHost(); }
            var upperLevelOff = SolveForPlace(height - 1, from, other);
            var desired = new (int, int)[] { (from, to) };
            ($"Move {wanted} from {from} to {to}").WriteHost();
            var upperLevelOn = SolveForPlace(height - 1, other, to);
            ret.AddRange(upperLevelOff);
            ret.AddRange(desired);
            ret.AddRange(upperLevelOn);
            return ret.ToArray();
        }
        public static bool EnsureSolved(int height, (int, int)[] moves)
        {
            var t = new Solution128.HanoiPuzzle(height);
            bool wasAlreadySolved = t.IsDone;
            foreach (var move in moves)
            {
                if (wasAlreadySolved) { return false; }
                t.TryMove(move);
                wasAlreadySolved = t.IsDone;
            }
            return t.IsValid && t.IsDone;
        }
        public class HanoiPuzzle
        {
            private Stack<int>[] towers;
            private object l = new object();
            public HanoiPuzzle(int height)
            {
                towers = new Stack<int>[] { new Stack<int>(Enumerable.Range(0, height).Reverse()), new Stack<int>(), new Stack<int>() };
            }
            public bool TryMove((int from, int to) move) => TryMove(move.from, move.to);
            public bool TryMove(int from, int to)
            {
                lock (l)
                {
                    try
                    {
                        var disk = towers[from].Pop();
                        try
                        {
                            if (towers[to].Count > 0 && towers[to].Peek() < disk) { throw new Exception(); }
                            towers[to].Push(disk);
                        }
                        catch (System.Exception)
                        {
                            towers[from].Push(disk);
                        }
                    }
                    catch (System.Exception) { return false; }
                    if (!IsValid) { throw new System.InvalidOperationException("Somehow this is in an invalid state."); }
                    return true;
                }
            }
            public bool IsDone => towers[0].Count == 0 && towers[1].Count == 0 && towers[2].SequenceEqual(towers[2].OrderBy(n => n));
            public bool IsValid => towers[0].SequenceEqual(towers[0].OrderBy(n => n)) && towers[1].SequenceEqual(towers[1].OrderBy(n => n)) && towers[2].SequenceEqual(towers[2].OrderBy(n => n));
            public string Print() => Common.Extensions.CollectionExtensions.Print(towers, "\n", t => t.Print(","));
            public override string ToString() => towers.Select(t => t.Count).Print(",");
        }
    }
}