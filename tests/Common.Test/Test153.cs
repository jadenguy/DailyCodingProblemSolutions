// Find an efficient algorithm to find the smallest distance (measured in number of words) between any two given words in a string.
// For example, given words "hello", and "world" and a text content of "dog cat hello cat dog dog hello cat world", return 1 because there's only one word "cat" in between the two words.

using System.Collections;
using NUnit.Framework;

namespace Common.Test
{
    public class Test153
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Case153))]
        public void Problem153(string str, string word1, string word2, int distance)
        {
            //-- Assert
            var expected = distance;

            //-- Arrange
            int actual = Solution153.ShortestDistanceBetweenWords(str, word1, word2) - 1;

            //-- Act
            Assert.AreEqual(expected, actual);
        }

        private class Case153 : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                var phrase = "dog cat hello cat dog dog hello cat world";
                var word1 = "hello";
                var word2 = "world";
                var distance = 1;
                yield return new object[] { phrase, word1, word2, distance };
            }
        }
    }
}
