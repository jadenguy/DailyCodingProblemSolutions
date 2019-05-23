// Implement regular expression matching with the following special characters:
// •	. (period) which matches any single character
// •	* (asterisk) which matches zero or more of the preceding element
// That is, implement a function that takes in a string and a valid regular expression and returns whether or not the string matches the regular expression.
// For example, given the regular expression "ra." and the string "ray", your function should return true. The same regular expression on the string "raymond" should return false.
// Given the regular expression ".*at" and the string "chat", your function should return true. The same regular expression on the string "chats" should return false.


using System.Collections.Generic;
using Common.Node;
using Common.Regex;
using NUnit.Framework;

namespace Common.Test
{
    public class Test25
    {
        [SetUp]
        public void Setup() { }
        [Test]
        [TestCase("ray", "ra.*", true)]
        [TestCase("ra", "ra.*", true)]
        [TestCase("array", "ra.*", false)]
        [TestCase("array", "ra.", false)]
        [TestCase("r", "ra.", false)]
        public void Problem25(string input, string test, bool passes)
        {
            //-- Arrange
            var expected = passes;

            //-- Act
            var actual = Solution25.Regex(input, test);

            //-- Assert
            // Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase("rr", 'r', true, true)]
        [TestCase("rr", 'r', false, false)]
        [TestCase("", 'r', true, true)]
        [TestCase("", 'r', false, false)]
        [TestCase("r", 'r', false, true)]
        [TestCase("r", 'r', true, true)]
        [TestCase("a", 'r', false, false)]
        [TestCase("a", '.', false, true)]
        public void RegexRuleWorks(string input, char testChar, bool zeroOrMore, bool passes)
        {
            //-- Arrange
            var expected = passes;

            var rule = new RegexRule(testChar, zeroOrMore);

            //-- Act
            var actual = rule.Test(input);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}