// Given an array of integers where every integer occurs three times except for one integer, which only occurs once, find and return the non-duplicated integer.
// For example, given [6, 1, 3, 3, 3, 6, 6], return 1. Given [13, 19, 13, 13], return 19.
// Do this in O(N) time and O(1) space.

using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test040
    {
        // [SetUp]
        // public void Setup() { }
        // [TearDown]
        // public void TearDown() { }
        [Test]
        [TestCase(new int[] { 6, 1, 3, 3, 3, 6, 6 }, 1)]
        public void Problem040Illustrative(int[] array, int results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            // var actual = Solution040.FindUnique(array);
            List<int> actual = new List<int>(Solution040.FindUniqueUsingCommonSet(array.Shuffle().ToArray()));

            //-- Assert
            Assert.AreEqual(expected, actual.First());
        }
        [Test]
        [TestCase(new int[] { 6, 1, 3, 3, 3, 6, 6 }, 1)]
        public void Problem040(int[] array, int results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            var actual = Solution040.FindUnique(array.Shuffle().ToArray());
            // var actual = Solution040.FindUniqueUsingCommonSet(array);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}