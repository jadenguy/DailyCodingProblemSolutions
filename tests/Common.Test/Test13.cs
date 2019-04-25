// Given an integer k and a string s, find the length of the longest substring that contains at most k distinct characters.
// For example, given s = "abcba" and k = 2, the longest substring with k distinct characters is "bcb".
using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test13
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("abcba",2,"bcb")]
        public void Problem12(string s, int k, string answer)
        {
            //-- Arrange
            var expected = answer;

            //-- Act
            var actual = Solution13.

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}