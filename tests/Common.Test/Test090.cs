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
        [TestCase(2, new int[] { 0 })]
        [TestCase(3, new int[] { })]
        [TestCase(3, new int[] { 0 })]
        [TestCase(3, new int[] { 0, 1 })]
        // [TestCase(1, new int[] { 0 })] // invalid test
        public void Problem090(int n = 3, int[] z = null)
        {
            //-- Arrange
            if (z == null) { z = new int[] { }; }
            double rounds = 1000;
            var expectedAverage = rounds / (n - z.Length);
            var expectedStdDev = 1 + expectedAverage * .1; // within 5 percent of the expected average
            var buckets = Enumerable.Range(0, n).ToDictionary(k => k, v => 0);

            //-- Act
            try
            {
                var negativeDice = new NegativeDice(n, z);
                for (int i = 0; i < rounds; i++)
                {
                    buckets[negativeDice.Next()]++;
                }
            }
            catch (System.Exception) { Assert.Fail(); }
            var rightNumbers = buckets.Keys.Except(z).Select(k => buckets[k]).Select(k => (double)k);
            var wrongNumbers = buckets.Keys.Intersect(z).Select(k => buckets[k]).Select(k => (double)k);
            var actualAverage = rightNumbers.Average();
            var actualStdDev = rightNumbers.PopulationStandardDeviation();

            System.Console.WriteLine(actualAverage);
            System.Console.WriteLine(expectedAverage);
            System.Console.WriteLine(actualStdDev);
            System.Console.WriteLine(expectedStdDev);
            System.Console.WriteLine(rightNumbers.Count());

            //-- Assert
            Assert.AreEqual(expectedAverage, actualAverage, 1, "average wrong");
            Assert.IsTrue(expectedStdDev > actualStdDev, "deviation wrong");
            Assert.IsTrue(wrongNumbers.Sum() == 0, "errant values");

        }
    }
}