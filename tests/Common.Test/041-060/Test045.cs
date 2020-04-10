// Using a function rand5() that returns an integer from 1 to 5 (inclusive) with uniform probability, implement a function rand7() that returns an integer from 1 to 7 (inclusive).

using System;
using System.Linq;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test045
    {
        Random rand = new Random(45);
        private const double stDevTolerance = .1;
        private const double avgTolerance = .1;
        private const int nRuns = 1000;
        // [SetUp] public void Setup() {}
        // [TearDown] public void TearDown(){}
        [Test]
        public void Problem045()
        {
            //-- Arrange
            var expected = Enumerable.Range(0, nRuns).SelectMany(k => Enumerable.Range(1, 7)).ToArray();

            //-- Act
            var actual = Enumerable.Range(0, nRuns).SelectMany(k => Enumerable.Range(1, 7).Select(v => Solution045.Rand7(rand.Next()))).ToArray();

            //-- Assert
            Assert.AreEqual(expected.SampleStandardDeviation(), actual.SampleStandardDeviation(), stDevTolerance, "standard deviation wrong");
            Assert.AreEqual(expected.Average(), actual.Average(), avgTolerance , "average wrong");
        }
        [Test]
        public void Problem045Control()
        {
            //-- Arrange
            var expected = Enumerable.Range(0, nRuns).SelectMany(k => Enumerable.Range(1, 5)).ToArray();

            //-- Act
            var actual = Enumerable.Range(0, nRuns).SelectMany(k => Enumerable.Range(1, 5).Select(v => Solution045.Rand5(rand.Next()))).ToArray();

            //-- Assert
            Assert.AreEqual(expected.SampleStandardDeviation(), actual.SampleStandardDeviation(), stDevTolerance, "standard deviation wrong");
            Assert.AreEqual(expected.Average(), actual.Average(), avgTolerance , "average wrong");
        }
    }
}