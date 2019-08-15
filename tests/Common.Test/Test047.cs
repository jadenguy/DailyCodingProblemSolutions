// Given a array of numbers representing the stock prices of a company in chronological order, write a function that calculates the maximum profit you could have made from buying and selling that stock once. You must buy before you can sell it.
// For example, given [9, 11, 8, 5, 7, 10], you should return 5, since you could buy the stock at 5 dollars and sell it at 10 dollars.

using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test047
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(new int[] { 9, 11, 8, 5, 7, 10 }, 5)]
        [TestCase(new int[] { 3, 2, 1, 10, 20, 30 }, 1)]
        public void Problem047(int[] prices, int buyPrice)
        {
            //-- Arrange
            int expected = buyPrice;

            //-- Act
            int actual = Solution047.FindBestBuyPriceNaive(prices).Low;

            // //-- Assert
            Assert.AreEqual(expected, prices[actual]);
        }
    }
}