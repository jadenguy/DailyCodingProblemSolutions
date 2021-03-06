// Given a string of round, curly, and square open and closing brackets, return whether the brackets are balanced (well-formed).
// For example, given the string "([])[]({})", you should return true.
// Given the string "([)]" or "((()", you should return false.

using NUnit.Framework;

namespace Common.Test
{
    public class Test027
    {


        [SetUp]
        public void Setup() { }
        [Test]
        [TestCase("([])[]({})", true)]
        [TestCase("([)]", false)]
        [TestCase("((()", false)]

        public void Problem027(string input, bool valid)
        {
            //-- Arrange
            var expected = valid;

            //-- Act
            var actual = Solution027.Validate(input);

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}