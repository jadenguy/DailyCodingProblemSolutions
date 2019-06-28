// Given three 32-bit integers x, y, and b, return x if b is 1 and y if b is 0, using only mathematical or bit operations. You can assume b can only be 1 or 0.

using NUnit.Framework;

namespace Common.Test
{
    public class Test85
    {
        [SetUp]
        public void Setup() { }
        [Test]
        [TestCase(1, 2, 0, 1)]
        [TestCase(1, 2, 1, 2)]
        [TestCase(1, -2, 1, -2)]
        [TestCase(1, -2, 0, 1)]
        [TestCase(-1, 2, 1, 2)]
        [TestCase(-1, 2, 0, -1)]
        public void Problem85(int x, int y, int b, int result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            var actual = Solution85.Choose(x, y, b);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}