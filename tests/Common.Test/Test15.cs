// The area of a circle is defined as πr^2. Estimate π to 3 decimal places using a Monte Carlo method.
// Hint: The basic equation of a circle is x2 + y2 = r2.

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test15
    {
        public int[] array;
        [SetUp]
        public void SetUp() { array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }; }
        [Test]
        public void StreamElementSelector()
        {
            //-- Arrange
            var expected = array[0];
            var streamElementSelector = new StreamElementSelector<int>();

            //-- Act
            int actual = streamElementSelector.SuggestElement(array[0]);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase(7777)]
        public void Problem15(int cycles)
        {
            //-- Arrange
            var expected = 1d;
            var average = cycles / (double)array.Length;
            var returnedValues = array.ToDictionary(a => a, a => 0);

            //-- Act
            for (int i = 0; i < cycles; i++)
            {
                var streamElementSelector = new StreamElementSelector<int>();
                returnedValues[Solution15.StreamElements(streamElementSelector, array)]++;
            }

            //-- Assert
            foreach (var item in array)
            {
                var actual = returnedValues[item] / average;
                Assert.AreEqual(expected, actual, .1);
            }
        }
    }
}