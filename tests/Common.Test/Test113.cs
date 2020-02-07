// Given a string of words delimited by spaces, reverse the words in string. For example, given "hello world here", return "here world hello"
// Follow-up: given a mutable string representation, can you perform this operation in-place?

using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test113
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase("hello world here", "here world hello")]
        [TestCase("a ", " a")]
        [TestCase("d  abc", "abc  d")]
        [TestCase("d   abc", "abc   d")]
        [TestCase("a", "a")]
        [TestCase("d abc", "abc d")]
        [TestCase("abc d", "d abc")]
        public void Problem113(string input, string result)
        {
            //-- Arrange
            input.WriteHost("input");
            result.WriteHost("desired");
            var expected = result;

            //-- Act
            var actual = Solution113.ReverseWordOrder(input);
            actual.WriteHost("results");

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}