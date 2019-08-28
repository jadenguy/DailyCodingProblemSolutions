// Using a function rand7() that returns an integer from 1 to 7 (inclusive) with uniform probability, implement a function rand5() that returns an integer from 1 to 5 (inclusive).

using System.Linq;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test071
    {
        private const int rounds = 50;

        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown(){}
        [Test]
        public void Problem071()
        {
            //-- Arrange
            double expected = rounds;
            double expectedStdDev = rounds / 10;
            var actual = new double[5];

            //-- Act
            for (int i = 0; i < rounds * 5; i++)
            {
                actual[Solution071.rand5()]++;
            }
            double actualAvg = actual.Average();
            double actualStdDev = actual.PopulationStandardDeviation();

            //-- Assert
            Assert.AreEqual(expected, actualAvg);
            Assert.AreEqual(expectedStdDev, actualStdDev, 10);
        }
    }
}