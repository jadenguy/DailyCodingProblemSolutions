// You are given n numbers as well as n probabilities that sum up to 1. Write a function to generate one of the numbers with its corresponding probability.
// For example, given the numbers [1, 2, 3, 4] and probabilities [0.1, 0.5, 0.2, 0.2], your function should return 1 10% of the time, 2 50% of the time, and 3 and 4 20% of the time.

using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;
using System.Collections;

namespace Common.Test
{
    public class Test152
    {
        private const int bunch = 10000;

        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases152))]
        public void Problem152(object[] objects, double[] probabilities)
        {
            //-- Assert
            int count = objects.Count();
            var rounds = bunch * count;
            var table = objects.ToDictionary(n => n, v => 0);

            //-- Arrange
            for (int i = 0; i < rounds; i++)
            {
                table[Solution152.WeightedRandom(objects, probabilities, 152)]++;
            }

            //-- Act
            Assert.Pass();
        }
        private class Cases152 : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { };
            }
        }
    }
}
