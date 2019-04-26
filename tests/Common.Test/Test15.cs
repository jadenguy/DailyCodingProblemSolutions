// The area of a circle is defined as πr^2. Estimate π to 3 decimal places using a Monte Carlo method.
// Hint: The basic equation of a circle is x2 + y2 = r2.

using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test15
    {
        public int[] array;
        [SetUp]
        public void SetUp() { array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }; }
        [Test]
        public void Problem15BasicInput(int[] stream)
        {
            //-- Arrange
            var expected = System.Math.PI;
            var streamRandomizer = new StreamRandomizer<int>();

            //-- Act
            int actual = 0;
            var x = streamRandomizer.RandomizeElement(array[0]);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}