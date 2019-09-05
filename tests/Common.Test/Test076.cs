// You are given an N by M 2D matrix of lowercase letters. Determine the minimum number of columns that can be removed to ensure that each row is ordered from top to bottom lexicographically. That is, the letter at each column is lexicographically later as you go down each row. It does not matter whether each row itself is ordered lexicographically.
// For example, given the following table:
// cba
// daf
// ghi
// This is not ordered because of the a in the center. We can remove the second column to make it ordered:
// ca
// df
// gi
// So your function should return 1, since we only needed to remove 1 column.
// As another example, given the following table:
// abcdef
// Your function should return 0, since the rows are already ordered (there's only one row).
// As another example, given the following table:
// zyx
// wvu
// tsr
// Your function should return 3, since we would need to remove all the columns to order it.

using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test076
    {
        [SetUp]
        public void Setup()
        {
            var testCase = new List<string[]>();
            var testResult = new List<int>();
            testCase.Add(new string[] { "cba", "daf", "ghi" });
            testResult.Add(1);
            testCase.Add(new string[] { "abcdef" });
            testResult.Add(0);
            testCase.Add(new string[] { "zyx", "wvu", "tsr" });
            testResult.Add(3);
            testCases = testCase.ToArray();
            testResults = testResult.ToArray();
        }
        // [TearDown] public void TearDown(){}
        string[][] testCases;
        int[] testResults;

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Problem076(int testIndex)
        {
            //-- Arrange
            string[] rows = testCases[testIndex];
            var expected = testResults[testIndex];

            //-- Act
            var actual = Solution076.MinimumRemovedColumns(rows);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}