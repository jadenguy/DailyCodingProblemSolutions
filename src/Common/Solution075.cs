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
        public static int LongestRaisingSequenceBinaryTree(int[] sequence)
        {
            var ret = 0;
            var node = BinarySearchNode.GenerateBinarySearchNode(sequence);
            var nodeList = node.BreadthFirstSearch();
            var split = nodeList.Select(g => g.Name.Split('.'));
            var splitCount = split.ToDictionary(k => k, r => r.Reverse().TakeWhile(f => f == "Right").Count());
            ret = splitCount.Values.Max() + 1;
            return ret;
        }
        public static int LongestRaisingSequence(int[] sequence)
        {
            var greaterPlaces = sequence.ToDictionary(n => n, n => 1);
            for (int j = sequence.Length - 1; j >= 0; j--)
            {
                int value = sequence[j];
                var futureSpaces = sequence.Skip(j).Where(r => r > value);
                var enumerable = greaterPlaces.Where(k => futureSpaces.Contains(k.Key));
                try
                {
                    int nextKey = enumerable.OrderByDescending(v => v.Value).First().Key;
                    greaterPlaces[value] += greaterPlaces[nextKey];
                }
                catch (System.Exception)
                {
                    System.Diagnostics.Debug.WriteLine("no increasing values after here");
                }
            }
            return greaterPlaces.Values.Max();
        }
    }
}