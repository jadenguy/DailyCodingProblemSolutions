// Given a string, return whether it represents a number. Here are the different kinds of numbers:
// •	"10", a positive integer
// •	"-10", a negative integer
// •	"10.1", a positive real number
// •	"-10.1", a negative real number
// •	"1e5", a number in scientific notation
// And here are examples of non-numbers:
// •	"a"
// •	"x 1"
// •	"a -2"
// •	"-"

// I'm assuming that 1e1e2 is invalid, not 1e100

using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test123
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase("10", true)]
        [TestCase("-10", true)]
        [TestCase("10.1", true)]
        [TestCase("-10.1", true)]
        [TestCase("1e5", true)]
        [TestCase("1e-2", true)]
        [TestCase("a", false)]
        [TestCase("x 1", false)]
        [TestCase("a -2", false)]
        [TestCase("-", false)]
        [TestCase("192.168.0.1", false)]
        [TestCase("1ee1", false)]
        [TestCase("-.", false)] //maybe?
        public void Problem123(string input, bool isNumeric)
        {
            //-- Arrange
            var expected = isNumeric;
            input.WriteHost("Source");
            expected.WriteHost("Expected");

            //-- Act
            bool actual = Solution123.TryConvertNumeric(input, out var result);
            actual.WriteHost("Actual");
            result.WriteHost();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}