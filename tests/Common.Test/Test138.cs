// Find the minimum number of coins required to make n cents.
// You can use standard American denominations, that is, 1¢, 5¢, 10¢, and 25¢.
// For example, given n = 16, return 3 since we can make it with a 10¢, a 5¢, and a 1¢.


using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;
using System.Collections;

namespace Common.Test
{
    public class Test138
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem138(int[] denominations, int n, int result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            int actual = denominations.MinimumCoinCount(n);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                int[] american = new int[] { 1, 5, 10, 25 };
                yield return new object[] { american, 16, 3 };
                yield return new object[] { new int[] { 9, 6, 5, 1 }, 11, 2 };
            }
        }
    }
}