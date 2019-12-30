// Given two strings A and B, return whether or not A can be shifted some number of times to get B.
// For example, if A is abcde and B is cdeab, return true. If A is abc and B is acb, return false.

using NUnit.Framework;

namespace Common.Test
{
    public class Test108
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase("abcde", "cdeab", true)]
        [TestCase("abc", "acb", false)]
        public void Problem108(string a, string b, bool result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            var actual = Solution108.IsStringRotation(a, b);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}