// Assume you have access to a function toss_biased() which returns 0 or 1 with a probability that's not 50-50 (but also not 0-100 or 100-0). You do not know the bias of the coin.
// Write a function to simulate an unbiased coin toss.


using System.Linq;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test066
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown(){}
        [Test]
        public void Problem066()
        {
            //-- Arrange
            var length = 1000;
            var expectedAverage = .5;
            var expectedStdDev = .5;
            var coin = new UnbalancedCoin();
            bool[] actual = new bool[length];

            //-- Act
            for (int i = 0; i < length; i++)
            {
                actual[i] = coin.TossUnbiased();
            }
            var actualNumeric = actual.Select(k => k ? 0d : 1d);
            var actualAverage = actualNumeric.Average();
            var actualStdDev = actualNumeric.PopulationStandardDeviation();


            //-- Assert
            Assert.AreEqual(expectedAverage, actualAverage, .1, "average wrong");
            Assert.AreEqual(expectedStdDev, actualStdDev, .1, "deviation wrong");
        }
    }
}