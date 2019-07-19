// Implement integer exponentiation. That is, implement the pow(x, y) function, where x and y are integers and returns x^y.
// Do this faster than the naive method of repeated multiplication.
// For example, pow(2, 10) should return 1024.

using NUnit.Framework;

namespace Common.Test
{
    public class Test061
    {
        [SetUp]
        public void Setup() { }
        [Test]
        [TestCase(2, 10, 1024)]
        [TestCase(2, 31, 2147483648)]
        [TestCase(8, 7, 2097152)]
        public void Problem61(float x, int y, float result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            var actual = Solution061.power(x, y);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}