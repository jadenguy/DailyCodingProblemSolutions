// Given an unsigned 8-bit integer, swap its even and odd bits. The 1st and 2nd bit should be swapped, the 3rd and 4th bit should be swapped, and so on.
// For example, 10101010 should be 01010101. 11100010 should be 11010001.

using NUnit.Framework;

namespace Common.Test
{
    public class Test109
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(0b10101010, 0b01010101)]
        public void Problem109(byte input, byte result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            var actual = Solution109.SwapOddEven(input);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}