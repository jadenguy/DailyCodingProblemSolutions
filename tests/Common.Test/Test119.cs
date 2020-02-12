// Given a set of closed intervals, find the smallest set of numbers that covers all the intervals. If there are multiple smallest sets, return any of them.
// For example, given the intervals [0, 3], [2, 6], [3, 4], [6, 9], one set of numbers that covers all these intervals is {3, 6}.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test119
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem119((int, int)[] input, int[][] result)
        {
            //-- Arrange
            var expected = result.Select(r => r.ToHashSet(h => h));
            input.Print(",").WriteHost("Source");
            expected.Print("; ", n => "[" + (n as IEnumerable<int>).Print(",") + "]").WriteHost("Expected");

            //-- Act
            var actual = Solution119.NumbersCoveringIntervals(input);
            ("[" + actual.Print(",") + "]").WriteHost("Actual");

            // //-- Assert
            Assert.IsTrue(expected.Where(e => e.SetEquals(actual)).Any());
        }
        class Cases : IEnumerable
        {
            private const int rangeStart = 0;
            private const int rangeLength = 3;
            public IEnumerator GetEnumerator()
            {
                (int, int)[] intervals;
                int[][] coveringIntegerSets;
                intervals = new (int, int)[] { (0, 3), (2, 6), (3, 4), (6, 9) };
                coveringIntegerSets = new int[][] { new int[] { 3, 6 } };
                yield return new object[] { intervals, coveringIntegerSets };

                intervals = new (int, int)[] { (rangeStart, rangeStart + rangeLength) };
                coveringIntegerSets = Enumerable.Range(rangeStart, 1 + rangeLength).Select(n => new int[] { n }).ToArray();
                yield return new object[] { intervals, coveringIntegerSets };

                intervals = new (int, int)[] { (rangeStart, rangeStart + rangeLength), (1 - rangeStart, 1 + rangeStart + rangeLength) };
                coveringIntegerSets = Enumerable.Range(rangeStart + 1, rangeLength).Select(n => new int[] { n }).ToArray();
                yield return new object[] { intervals, coveringIntegerSets };
            }
        }
    }
}
