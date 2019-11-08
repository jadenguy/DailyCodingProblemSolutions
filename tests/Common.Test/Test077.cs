// Given a list of possibly overlapping intervals, return a new list of intervals where all overlapping intervals have been merged.
// The input list is not necessarily ordered in any way.
// For example, given [(1, 3), (5, 8), (4, 10), (20, 25)], you should return [(1, 3), (4, 10), (20, 25)].


using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test077
    {
        [SetUp]
        public void Setup()
        {
            var testCase = new List<(int, int)[]>();
            var testResult = new List<(int, int)[]>();
            testCase.Add(new (int, int)[] { (5, 10), (4, 8), (1, 3), (20, 25) });
            testResult.Add(new (int, int)[] { (1, 3), (4, 10), (20, 25) });
            testCases = testCase.ToArray();
            testResults = testResult.ToArray();
        }
        // [TearDown] public void TearDown(){}
        (int, int)[][] testCases;
        (int, int)[][] testResults;

        [Test]
        [TestCase(0)]
        public void Problem077(int testIndex)
        {
            //-- Arrange
            var array = testCases[testIndex];
            var expected = testResults[testIndex];

            //-- Act
            var actual = Solution077.MergedOverlapping(array);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}