// Given an array of integers, find the first missing positive integer in linear time and constant space. In other words, find the lowest positive integer that does not exist in the array. The array can contain duplicates and negative numbers as well.
// For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.
// You can modify the input array in-place.

using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test004
    {

        [Test]
        [TestCase(new int[] { 1, 2, 4, 5 }, 3)]
        [TestCase(new int[] { 4, 1, 2, 5 }, 3)]
        [TestCase(new int[] { 100, 99, 98, 5, 4, 1, 2, 4, 4, 5, 1, 2, 4, 4, 5, 1, 2, 4, 4, 5, 1, 2, 4, 4, 5 }, 3)]
        [TestCase(new int[] { 5, 0, 0, -1, 4 }, 1)]
        public void Problem004(int[] list, int answer)
        {
            //-- Arrange
            var expected = answer;

            //-- Act
            var actual = Solution004.MissingPositiveInteger(list);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}