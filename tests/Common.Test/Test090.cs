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
        public void Problem090(int n = 2, int[] z = null)
        {
            //-- Arrange
            var length = 1000;
            var expectedAverage = .5;
            var expectedStdDev = .5;
            var negativeDice = new NegativeDice(n, z);
            int[] actual = new int[length];

            //-- Act
            for (int i = 0; i < length; i++)
            {
                actual[i] = negativeDice.Next();
            }
            var actualNumeric = actual.Select(k => (double)k);
            var actualAverage = actualNumeric.Average();
            var actualStdDev = actualNumeric.PopulationStandardDeviation();

            //-- Assert
            Assert.AreEqual(expectedAverage, actualAverage, .05, "average wrong");
            Assert.AreEqual(expectedStdDev, actualStdDev, .05, "deviation wrong");
        }
    }
}