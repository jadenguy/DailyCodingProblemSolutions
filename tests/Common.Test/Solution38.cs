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
            IEnumerable<int> positions = Enumerable.Range(0, n );
            int[][] enumerable = positions.EveryPermutation().ToArray();
            foreach (var permutation in enumerable)
            {
                if (permutation.VerifyCandidateNQueen(n))
                {
                    yield return permutation;
                    System.Diagnostics.Debug.WriteLine(permutation.Print());
                }
            }
        }
        public static bool VerifyCandidateNQueen(this int[] answer, int size)
        {
            var ret = answer.Count() == size;
            var i = 0;
            while (ret && i < size)
            {
                var j = 1;
                var k = answer[i];
                while (ret && j < size)
                {
                    int x = i;
                    int y = k;
                    int x2 = (i + j) % size;
                    int y2 = answer[x2];
                    double rise = (Math.Abs(y - y2));
                    double run = (Math.Abs(x - x2));
                    ret = rise / run != 1;
                    j++;
                }
                i++;
            }
            return ret;
        }
    }
}