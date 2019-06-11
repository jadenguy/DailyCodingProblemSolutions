// The area of a circle is defined as πr^2. Estimate π to 3 decimal places using a Monte Carlo method.
// Hint: The basic equation of a circle is x2 + y2 = r2.

using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test14
    {

        [Test]
        [TestCase(100000000)]
        public void Problem14(int steps)
        {
            //-- Arrange
            var expected = System.Math.PI;

            //-- Act
            var timer = System.Diagnostics.Stopwatch.StartNew();
            var actual = Solution14.CalculatePi(steps);
            System.Console.WriteLine(timer.ElapsedMilliseconds);

            //-- Assert
            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}