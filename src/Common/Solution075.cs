using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution075
    {
        public static int LongestRaisingSequenceOld(int[] sequence)
        {
            var array = HowManyAfterRaise(sequence).Reverse().ToArray();
            var howManyGreater = 0;
            // var previousHowManyGreater = 0;
            var ret = 1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == howManyGreater)
                {
                    howManyGreater++;
                    ret++;
                }
            }
            return ret;
        }
        private static IEnumerable<int> HowManyAfterRaise(int[] sequence)
        {
            int length = sequence.Length;
            for (int i = 0; i < length; i++)
            {
                System.Diagnostics.Debug.WriteLine(sequence.Skip(i).Where(n => n > sequence[i]).Count(), sequence[i].ToString());
                yield return sequence.Skip(i).Where(n => n > sequence[i]).Count();
            }
        }

        public static int LongestRaisingSequence(int[] sequence)
        {
            var ret = 0;
            var n = BinarySearchNode.GenerateBinarySearchNode(sequence);
            var z = n.BreadthFirstSearch();
            z.Select(g => g.Name.Split('.'));
            return ret;
        }
    }
}