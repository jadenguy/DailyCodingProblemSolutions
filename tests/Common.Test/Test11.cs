// Implement an autocomplete system. That is, given a query string s and a set of all possible query strings, return all strings in the set that have s as a prefix.
// For example, given the query string de and the set of strings [dog, deer, deal], return [deer, deal].
// Hint: Try preprocessing the dictionary into a more efficient data structure to speed up queries.

using NUnit.Framework;

namespace Common.Test
{
    public class Test11
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Problem11()
        {
            //-- Arrange
            var list = new string[] { "dog", "deer", "deal" };
            var input = "de";
            var expected = new string[] { "deer", "deal" };

            //-- Act
            var actual = Solution11.AutoComplete(list,input);

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}