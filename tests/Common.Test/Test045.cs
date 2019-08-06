// Using a function rand5() that returns an integer from 1 to 5 (inclusive) with uniform probability, implement a function rand7() that returns an integer from 1 to 7 (inclusive).

using System.Linq;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test045
    {
        [SetUp]
        public void Setup() { }
        [Test]
        public void Problem045(string text, string anagram)
        {
            //-- Arrange
            var expected = Enumerable.Range(0, 1000).SelectMany(k => Enumerable.Range(1, 7)).Select(z => (double)z).ToArray();
            //-- Act
            var actual = Enumerable.Range(0, 1000).SelectMany(k => Enumerable.Range(1, 7).Select(v => Solution045.Rand7())).Select(z => (double)z).ToArray();

            //-- Assert
            Assert.AreEqual(expected.SampleStandardDeviation(), actual.SampleStandardDeviation(), .01);
            Assert.AreEqual(expected.Average(), actual.Average(), .01);

        }
        [Test]
        public void Problem045Control(string text, string anagram)
        {
            //-- Arrange
            var expected = Enumerable.Range(0, 1000).SelectMany(k => Enumerable.Range(1, 5)).Select(z => (double)z).ToArray();
            //-- Act
            var actual = Enumerable.Range(0, 1000).SelectMany(k => Enumerable.Range(1, 5).Select(v => Solution045.Rand5())).Select(z => (double)z).ToArray();

            //-- Assert
            Assert.AreEqual(expected.SampleStandardDeviation(), actual.SampleStandardDeviation(), .01);
            Assert.AreEqual(expected.Average(), actual.Average(), .01);
        }
    }
}