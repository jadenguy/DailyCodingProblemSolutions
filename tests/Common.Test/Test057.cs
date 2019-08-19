// Given a string s and an integer k, break up the string into multiple lines such that each line has a length of k or less. You must break it up so that words don't break across lines. Each line has to have the maximum possible amount of words. If there's no way to break the text up, then return null.
// You can assume that there are no spaces at the ends of the string and that there is exactly one space between each word.
// For example, given the string "the quick brown fox jumps over the lazy dog" and k = 10, you should return: ["the quick", "brown fox", "jumps over", "the lazy", "dog"]. No string in the list has a length of more than 10.

using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test057
    {
        [SetUp]
        public void SetUp() { }
        [Test]
        [TestCase("the quick brown fox jumps over the lazy dog", 10)]
        public void Problem057(string text, int k)
        {
            //-- Arrange
            var expected = new string[] { "the quick", "brown fox", "jumps over", "the lazy", "dog" };

            //-- Act
            var actual = Solution057.TextToLines(text, k);

            //-- Assert
            int nonSpaces = text.Where(f => !f.Equals(' ')).Count();
            int spaces = text.Where(f => f.Equals(' ')).Count();
            int charactersReturned = actual.Sum(s => s.Length);
            Assert.AreEqual(nonSpaces, charactersReturned, spaces);
            Assert.AreEqual(expected, actual);
        }
    }
}