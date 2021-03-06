// Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
// For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
// Bonus: Can you do this in one pass?

using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test001
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] { 10, 15, 3, 7 }, 17, true)]
        [TestCase(new int[] { 17 }, 17, false)]
        [TestCase(new int[] { 16 }, 17, false)]
        [TestCase(new int[] { }, 17, false)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, 39, true)]
        [TestCase(new int[] { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, }, 39, true)]
        [TestCase(new int[] { 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, }, 40, false)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, 40, false)]
        public void Problem001(int[] list, int wanted, bool answer)
        {
            //-- Arrange
            var expected = answer;

            //-- Act
            var actual = Solution001.PairSumsContain(list, wanted);

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}