using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution075
    {
        public static int LongestRaisingSequence(int[] sequence)
        {
            var ret = 0;
            var array = NewMethod(sequence).ToArray();
            return ret;
        }

        private static IEnumerable<int> NewMethod(int[] sequence)
        {
            int length = sequence.Length;
            for (int i = 0; i < length; i++)
            {
                System.Diagnostics.Debug.WriteLine(sequence.Skip(i).Where(n => n > sequence[i]).Count(), sequence[i].ToString());
                yield return sequence.Skip(i).Where(n => n > sequence[i]).Count();
            }
        }
    }
}