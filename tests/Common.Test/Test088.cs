// Implement division of two positive integers without using the division, multiplication, or modulus operators. Return the quotient as an integer, ignoring the remainder.

using NUnit.Framework;

namespace Common.Test
{
    public class Test088
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }

        // PS C:\> "[Test]";1..10|%{[int]$a=(get-random)/1000;[int]$b=1+(get-random)/200000;"[TestCase($a,$b)]"}
        [Test]
        [TestCase(791749, 4216)]
        [TestCase(650693, 4019)]
        [TestCase(88238, 1539)]
        [TestCase(1534819, 466)]
        [TestCase(1449322, 4471)]
        [TestCase(671743, 7140)]
        [TestCase(732057, 5634)]
        [TestCase(1736901, 8748)]
        [TestCase(771659, 7398)]
        [TestCase(1957001, 4272)]
        public void Problem088(int numerator, int denominator)
        {
            //-- Arrange
            var expected = numerator / denominator;

            //-- Act
            var actual = Solution088.Divide(numerator, denominator);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}