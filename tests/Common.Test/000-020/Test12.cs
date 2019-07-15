// There exists a staircase with N steps, and you can climb up either 1 or 2 steps at a time. Given N, write a function that returns the number of unique ways you can climb the staircase. The order of the steps matters.
// For example, if N is 4, then there are 5 unique ways:
// •	1, 1, 1, 1
// •	2, 1, 1
// •	1, 2, 1
// •	1, 1, 2
// •	2, 2
// What if, instead of being able to climb 1 or 2 steps at a time, you could climb any number from a set of positive integers X? For example, if X = {1, 3, 5}, you could climb 1, 3, or 5 steps at a time.
using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test012
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(19, new int[] { 7, 13 }, 0)]
        [TestCase(20, new int[] { 7, 13 }, 2)]
        [TestCase(21, new int[] { 7, 13 }, 1)]
        [TestCase(1, new int[] { 1, 2 }, 1)]
        [TestCase(2, new int[] { 1, 2 }, 2)]
        [TestCase(3, new int[] { 1, 2 }, 3)]
        [TestCase(4, new int[] { 1, 2 }, 5)]
        [TestCase(14, new int[] { 12, 3, 1, 9 }, 150)]
        public void Problem12(int stairs, int[] steps, int answer)
        {
            //-- Arrange
            var expected = answer;

            //-- Act
            var actual = Solution12.CountStepPatterns(stairs, steps);

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}