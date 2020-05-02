// Given a stream of elements too large to store in memory, pick a random element from the stream with uniform probability.

using System;
using System.Collections.Generic;
using System.Linq;
using Common.RandomSelector;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test015
    {
        public int[] array;
        [SetUp]
        public void SetUp() => array = Enumerable.Range(0, 10).ToArray();
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
        [TestCase(10000)]
        public void Problem015(int cycles)
        {
            //-- Arrange
            var expectedNumberOfSelections = cycles / (double)array.Length;
            var expectedStDev = Math.Sqrt(cycles / array.Length);
            var returnedValues = array.ToDictionary(a => a, a => 0);

            //-- Act
            var rand = Rand.NewRandom(015);
            for (int i = 0; i < cycles; i++)
            {
                var streamElementSelector = new StreamElementSelector<int>(rand.Next());
                returnedValues[Solution015.StreamElements(streamElementSelector, array)]++;
            }
            var actualNumberOfSelections = returnedValues.Values.Average();
            var actualStDev = returnedValues.Select(v => (double)v.Value).SampleStandardDeviation();
            // System.Diagnostics.Debug.WriteLine(stDev, "Standard Deviation");
            // System.Diagnostics.Debug.WriteLine(expectedStDev, "Standard Deviation Range");
            // System.Diagnostics.Debug.WriteLine(actualNumberOfSelections, "Average");
            // System.Diagnostics.Debug.WriteLine(returnedValues.Print());

            //-- Assert
            Assert.AreEqual(expectedNumberOfSelections, actualNumberOfSelections, "Somehow you didn't select a member");
            Assert.AreEqual(expectedStDev, actualStDev, expectedStDev * .5, "The standard deviation is outside of expected values");
        }
    }
}