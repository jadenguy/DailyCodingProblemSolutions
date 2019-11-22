// Given an integer n and a list of integers l, write a function that randomly generates a number from 0 to n-1 that isn't in l (uniform).

using System.Linq;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test090
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown(){}
        [Test]
        [TestCase()]
        public void Problem090(int n = 3, int[] z = null)
        {
            //-- Arrange
            if (z == null) { z = new int[] { }; }
            var length = 1000;
            int buckets = (n - z.Length);
            var expectedAverage = length / buckets;
            var expectedStdDev = length / buckets / buckets;
            var negativeDice = new NegativeDice(n, z);
            var actual = Enumerable.Range(0, n).Except(z).ToDictionary(k => k, v => 0);

            //-- Act
            for (int i = 0; i < length; i++)
            {
                actual[negativeDice.Next()]++;
            }
            var actualNumeric = actual.Values.Select(k => (double)k);
            var actualAverage = actualNumeric.Average();
            var actualStdDev = actualNumeric.PopulationStandardDeviation();

            //-- Assert
            Assert.AreEqual(expectedAverage, actualAverage, 1, "average wrong");
            Assert.AreEqual(expectedStdDev, actualStdDev, .05, "deviation wrong");
            // Assert.Pass();
        }
    }
}