// Given a list of integers S and a target number k, write a function that returns a subset of S that adds up to k. If such a subset cannot be made, then return null.
// Integers can appear more than once in the list. You may assume all numbers in the list are positive.
// For example, given S = [12, 1, 61, 5, 9, 2] and k = 24, return [12, 9, 2, 1] since it sums up to 24.

using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test042
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(new int[] { 12, 1, 61, 5, 9, 2 }, 24, new int[] { 12, 9, 2, 1 })]
        [TestCase(new int[] { 12, 1, 61, 5, 9, 2 }, 100000, null)]
        public void Problem042(int[] S, int k, int[] results)
        {
            //-- Arrange
            int[] expected = null;
            if (results != null) { expected = results.OrderBy(n => n).ToArray(); }

            //-- Act
            var array = Solution042.SubsetSum(S.OrderBy(n => n), k);
            var actual = array.FirstOrDefault();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}