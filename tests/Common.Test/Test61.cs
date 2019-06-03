// Implement integer exponentiation. That is, implement the pow(x, y) function, where x and y are integers and returns x^y.
// Do this faster than the naive method of repeated multiplication.
// For example, pow(2, 10) should return 1024.

using NUnit.Framework;

namespace Common.Test
{
    public class Test61
    {
        [SetUp]
        public void Setup() { }
        [Test]
        [TestCase(2, 10, 1024)]
        [TestCase(8, 7, 2097152)]
        public void Problem25(float x, int y, int result)
        {
            //-- Arrange
            var expected = result;
            var sol = new Solution61();

            //-- Act
            var actual = sol.power(x, y);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}