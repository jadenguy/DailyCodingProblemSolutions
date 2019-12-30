// Given a word W and a string S, find all starting indices in S which are anagrams of W.
// For example, given that W is "ab", and S is "abxaba", return 0, 3, and 4.

using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test111
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase("ab", "abxaba", new int[] { 0, 3, 4 })]
        [TestCase("", "", new int[] { 0 })]
        public void Problem111(string W, string S, int[] result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            char[] subset = W.ToCharArray();
            char[] set = S.ToCharArray();
            var actual = Solution111.FindAnagramSubstringIndexes<char>(subset, set).ToArray();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}