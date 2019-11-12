// A number is considered perfect if its digits sum up to exactly 10.
// Given a positive integer n, return the n-th perfect number.
// For example, given 1, you should return 19. Given 2, you should return 28.

using NUnit.Framework;

namespace Common.Test
{
    public class Test070
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown(){}
        [Test]
        [TestCase(1, 19)]
        [TestCase(2, 28)]
        [TestCase(3, 37)]
        [TestCase(9, 91)]
        [TestCase(10, 109)]
        [TestCase(11, 118)]
        [TestCase(111, 1621)]
        public void Problem070(int n, int result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            var actual = Solution070.PerfectNumber(n);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}