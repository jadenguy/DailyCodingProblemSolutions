// The area of a circle is defined as πr^2. Estimate π to 3 double places using a Monte Carlo method.
// Hint: The basic equation of a circle is x2 + y2 = r2.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test014
    {
        private const int e6 = 1000000;
        private const int e5 = 100000;
        private const int e4 = 10000;
        private const int e3 = 1000;
        private const int e2 = 100;

        [Test]
        [TestCase(e4, e4)]
        // [TestCase(e4, e4)]
        // [TestCase(e4, e4)]
        // [TestCase(e4, e4)]
        // [TestCase(e4, e4)]
        // [TestCase(e4, e4)]
        // [TestCase(e4, e4)]
        // [TestCase(e4, e4)]
        // [TestCase(e4, e4)]
        // [TestCase(e4, e4)]
        // [TestCase(e4, e4)]
        // [TestCase(e4, e4)]
        // [TestCase(e5, e3)]
        // [TestCase(e6, e2)]
        // [TestCase(e4, e4)]
        // [TestCase(e5, e3)]
        // [TestCase(e6, e2)]
        // [TestCase(e4, e4)]
        // [TestCase(e5, e3)]
        // [TestCase(e6, e2)]
        public void Problem014(int steps, int parallel)
        {
            //-- Arrange
            var expected = System.Math.PI;

            //-- Act
            var timer = System.Diagnostics.Stopwatch.StartNew();
            var actual = Solution014.CalculatePi(steps, parallel);
            System.Diagnostics.Debug.WriteLine(steps);
            System.Diagnostics.Debug.WriteLine(parallel);
            System.Diagnostics.Debug.WriteLine(steps * parallel);
            System.Diagnostics.Debug.WriteLine(expected);
            System.Diagnostics.Debug.WriteLine(actual);
            System.Diagnostics.Debug.WriteLine(expected - actual);
            System.Diagnostics.Debug.WriteLine(timer.ElapsedMilliseconds);
            System.Console.WriteLine(timer.ElapsedMilliseconds);
            System.Console.WriteLine(expected - actual);


            //-- Assert
            Assert.AreEqual(expected, actual, 0.0005);
        }
    }
}