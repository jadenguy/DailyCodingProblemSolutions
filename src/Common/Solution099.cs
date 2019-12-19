using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution099
    {
        class Range
        {
            private int min;
            private int max;
            public Range(int min, int max)
            {
                Min = min;
                Max = max;
            }
            public int Max { get => max; set => max = value; }
            public int Min { get => min; set => min = value; }
            public int Count { get => Max - Min + 1; }
            public int[] Enumerate() => Enumerable.Range(Min, Count).ToArray();

            public override bool Equals(object obj)
            {
                var other = obj as Range;
                if (other is null) { return false; }
                return this.Min == other.Min && this.Max == other.Max;
            }
            public override int GetHashCode() => this.ToString().GetHashCode();
            public override string ToString() => $"Range {Min} {Max}";
        }
        public static int[] LongestConsecutiveSubset(int[] array)
        {
            var clusters = array.Select(c => new Range(c, c)).ToArray();
            MatchPairs(clusters);
            var orderedClusters = clusters.OrderByDescending(r => r.Count).ThenBy(r => r.Min).ToArray();
            var ranges = orderedClusters.Select(r => r.Enumerate()).ToArray();
            return ranges.First().ToArray();
        }
        private static void MatchPairs(Range[] clusters)
        {
            foreach (var cluster in clusters.OrderBy(c => c.Min))
            {
                var queue = new Queue<Range>(clusters);
                while (queue.Count > 0)
                {
                    var other = queue.Dequeue();
                    bool adjoiningCluster = other.Min == cluster.Max + 1;
                    bool notAlreadyUpdated = cluster.Max != other.Max;
                    if (adjoiningCluster && notAlreadyUpdated)
                    {
                        cluster.Max = other.Max;
                        other.Min = cluster.Min;
                        queue = new Queue<Range>(clusters.Distinct());
                    }
                }
            }
        }
    }
}