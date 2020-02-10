// Given a string and a set of delimiters, reverse the words in the string while maintaining the relative order of the delimiters. For example, given "hello/world:here", return "here/world:hello"
// Follow-up: Does your solution work for the following cases: "hello/world:here/", "hello//world:here"

// delimiter list assumed
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test114
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase("hello/world:here/", "/:", "here/world:hello/")]
        [TestCase("hello//world:here", "/:", "here//world:hello")]
        [TestCase("hello/world:here", "/:", "here/world:hello")]
        public void Problem114(string input, string delimiters, string result)
        {
            //-- Arrange
            input.WriteHost("input");
            result.WriteHost("desired");
            var expected = result;

            //-- Act
            var actual = Solution114.ReverseWordOrderDelimiterList(input, delimiters);
            actual.WriteHost("results");

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}