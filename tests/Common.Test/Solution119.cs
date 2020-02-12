using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public class Solution119
    {
        public static int[] NumbersCoveringIntervals((int start, int end)[] input)
        {
            var inputSet = new HashSet<(int, int)>(input);
            var start = input.Min(n => n.end);
            var end = input.Max(n => n.start);
            if (end < start) { (end, start) = (start, end); }
            var possibleCoveringIntegers = Enumerable.Range(start, end - start + 1);

            var coveredIntervals = possibleCoveringIntegers.ToDictionary(k => k, v => input.Where(r => r.start <= v && r.end >= v));

            var possibleSets = coveredIntervals.Keys.EverySubset();
            var possibleAnswers = possibleSets.ToDictionary(k => k, n => new HashSet<(int, int)>(n.SelectMany(g => coveredIntervals[g])));
            var answers = possibleAnswers.Where(v => v.Value.SetEquals(inputSet)).OrderBy(k => k.Key.Length);

            var ret = answers.FirstOrDefault().Key;
            return ret;
        }
    }
}