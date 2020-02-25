// Given an array of numbers representing the stock prices of a company in chronological order and an integer k, return the maximum profit you can make from k buys and sells. You must buy the stock before you can sell it, and you must sell the stock before you can buy it again.
// For example, given k = 2 and the array [5, 2, 4, 0, 1], you should return 3.

using System.Collections;
using System.Numerics;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test130
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem130(int[] array, int k, int profit)
        {
            //-- Arrange
            var expected = profit;
            array.Print(",").WriteHost("array");
            k.WriteHost("buys and sells");
            expected.WriteHost("best profit");

            //-- Act
            var actual = Solution130.BestProfit(array, k);
            actual.WriteHost("actual profit");

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new int[] { 5, 2, 4, 0, 1 }, 2, 3 };
            }
        }
    }
}