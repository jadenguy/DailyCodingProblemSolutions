// Given a string of parentheses, write a function to compute the minimum number of parentheses to be removed to make the string valid (i.e. each open parenthesis is eventually closed).
// For example, given the string "()())()", you should return 1. Given the string ")(", you should return 2, since we must remove all of them.

using NUnit.Framework;

namespace Common.Test
{
    public class Test086
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase]
        [TestCase("(", 1)]
        [TestCase(")(", 2)]
        [TestCase("(((((", 5)]
        [TestCase("(())", 0)]
        [TestCase(")))))", 5)]
        [TestCase("()())()", 1)]
        [TestCase("((((( this is all garbage +", 5)]
        public void Problem086(string content = "", int results = 0)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            int actual = Solution086.MissingParenthesisCount(content, out var suggestion);
            System.Console.WriteLine(suggestion);
            System.Diagnostics.Debug.WriteLine(suggestion);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}