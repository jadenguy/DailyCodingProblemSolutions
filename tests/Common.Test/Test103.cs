// Given a string and a set of characters, return the shortest substring containing all the characters in the set.
// For example, given the string "figehaeci" and the set of characters {a, e, i}, you should return "aeci".
// If there is no substring containing all the characters in the set, return null.

using NUnit.Framework;

namespace Common.Test
{
    public class Test103
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(nameof(Cases))]
        public void Problem103(string phrase, char[] letters, string results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            var returnCharArray = Solution103.ShortestInclusiveSubset(phrase.ToCharArray(), letters);

            // //-- Assert
            Assert.AreEqual(expected, string.Join(null, returnCharArray));
        }
        static object[] Cases = { new object[] { "figehaeci", new char[] { 'a', 'e', 'i' }, "aeci" } };
    }
}
