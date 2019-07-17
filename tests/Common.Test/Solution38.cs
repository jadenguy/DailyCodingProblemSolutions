using System;
using System.Linq;
using System.Collections.Generic;
using Common.Extensions;

namespace Common.Test
{
    public static class Solution38
    {
        public static IEnumerable<int[]> NQueens(int n)
        {
            IEnumerable<int> positions = Enumerable.Range(0, n);
            int[][] enumerable = positions.EveryPermutation().ToArray();
            foreach (var permutation in enumerable)
            {
                if (permutation.VerifyCandidateNQueen(n))
                {
                    yield return permutation;
                    // System.Diagnostics.Debug.WriteLine(permutation.Print(" "));
                }
            }
        }
        public static bool VerifyCandidateNQueen(this int[] answer, int size)
        {
            var ret = answer.Count() == size;
            for (int x = 0; ret && x + 1 < size; x++)
            {
                var y = answer[x];
                for (int xDelta = 1; ret && x + xDelta < size; xDelta++)
                {
                    var x2 = x + xDelta;
                    var y2 = answer[x2];
                    double rise = Math.Abs(y - y2);
                    double run = Math.Abs(x - x2);
                    ret = rise / run != 1;
                }
            }
            return ret;
        }
    }
}