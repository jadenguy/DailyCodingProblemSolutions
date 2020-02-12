// Given a set of closed intervals, find the smallest set of numbers that covers all the intervals. If there are multiple smallest sets, return any of them.
// For example, given the intervals [0, 3], [2, 6], [3, 4], [6, 9], one set of numbers that covers all these intervals is {3, 6}.

using System.Collections;
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
        public void Problem119((int, int)[] input, int[] result)
        {
            //-- Arrange
            var expected = result.OrderBy(n => n);
            input.Print(",").WriteHost("Source");
            expected.Print(",").WriteHost("Expected");

            //-- Act
            var actual = Solution119.NumbersCoveringIntervals(input);
            actual.Print(",").WriteHost("Actual");

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        class Cases : IEnumerable
        {
            private const int testCountPer = 10;
            private System.Random rand = new System.Random(119);
            public IEnumerator GetEnumerator()
            {
                (int, int)[] x;
                int[] y;
                x = new (int, int)[] { (0, 3), (2, 6), (3, 4), (6, 9) };
                y = new int[] { 3, 6 };
                yield return new object[] { x, y };
            }
        }
    }
}
