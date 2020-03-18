// Find the minimum number of coins required to make n cents.
// You can use standard American denominations, that is, 1¢, 5¢, 10¢, and 25¢.
// For example, given n = 16, return 3 since we can make it with a 10¢, a 5¢, and a 1¢.


using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Test
{
    public class Test138
    {
        static int[] denominations = new int[] { 1, 5, 10, 25 };
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(16, 3)]
        public void Problem138(int n, int result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            int actual = denominations.MinimumCoinCount(n);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}