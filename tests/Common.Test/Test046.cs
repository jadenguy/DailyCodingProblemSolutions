// Given a string, find the longest palindromic contiguous substring. If there are more than one with the maximum length, return any one.
// For example, the longest palindromic substring of "aabcdcb" is "bcdcb". The longest palindromic substring of "bananas" is "anana".

using NUnit.Framework;

namespace Common.Test
{
    public class Test046
    {
        [SetUp]
        public void Setup() { }
        [Test]
        [TestCase("bananas", "anana")]
        public void Problem25(string text, string anagram)
        {
            //-- Arrange
            var expected = anagram;
            //-- Act
            var actual = Solution046.FindLongestAnagram(text);
            //-- Assert
            Assert.AreEqual(expected.Length, actual.Length);
        }
    }
}