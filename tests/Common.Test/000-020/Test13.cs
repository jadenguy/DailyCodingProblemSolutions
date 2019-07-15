// Given an integer k and a string s, find the length of the longest substring that contains at most k distinct characters.
// For example, given s = "abcba" and k = 2, the longest substring with k distinct characters is "bcb".
using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test013
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("abcba",2,"bcb")]
        [TestCase("abcba",3,"abcba")]
        public void Problem12(string s, int k, string answer)
        {
            //-- Arrange
            var expected = answer;

            //-- Act
            var actual = Solution13.SubSpecial(s,k);

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}