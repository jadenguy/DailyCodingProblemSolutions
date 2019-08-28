// Using a function rand7() that returns an integer from 1 to 7 (inclusive) with uniform probability, implement a function rand5() that returns an integer from 1 to 5 (inclusive).

using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test071
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown(){}
        [Test]
        public void Problem071()
        {
            //-- Arrange
            var expected = 100;
            int expectedStdDev = 10;
            var actual = new double[5];

            //-- Act
            for (int i = 0; i < 100 * 5; i++)
            {
                actual[Solution071.rand5()]++;
            }
            double actualAvg = actual.Average();
            double actualStdDev = Common.Extensions.MathExtensions.PopulationStandardDeviation(actual);



            //-- Assert
            Assert.AreEqual(expected, actualAvg, 10);
            Assert.AreEqual(expectedStdDev, actualStdDev, 10);
        }
    }
}