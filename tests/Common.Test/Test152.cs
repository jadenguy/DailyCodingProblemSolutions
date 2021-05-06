// You are given n numbers as well as n probabilities that sum up to 1. Write a function to generate one of the numbers with its corresponding probability.
// For example, given the numbers [1, 2, 3, 4] and probabilities [0.1, 0.5, 0.2, 0.2], your function should return 1 10% of the time, 2 50% of the time, and 3 and 4 20% of the time.

using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Common.Test
{
    public class Test152
    {

        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases152))]
        public void Problem152(IEnumerable<object> objects, double[] probabilities, int rounds)
        {
            //-- Assert
            var objects1 = objects.ToArray();
            var table = objects1.ToDictionary(n => n, v => 0);
            var expected = probabilities.Select(p => p * rounds).ToArray();
            var r = new Solution152(152);

            //-- Arrange
            for (int i = 0; i < rounds; i++)
            {
                table[r.WeightedRandom(objects1, probabilities)]++;
            }

            //-- Act
            for (int i = 0; i < objects1.Length; i++)
            {
                Assert.AreEqual(expected[i], table[objects1[i]], 10);
            }
        }
        private class Cases152 : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                object[] objects;
                double[] probibilaties;
                int rounds;

                // Simple Test
                objects = new object[] { 'a', 'b' };
                probibilaties = new[] { .5, .5 };
                rounds = 100000;
                yield return new object[] { objects, probibilaties, rounds };

                // Slightly More Complicated test
                objects = new object[] { 'a', 'b' };
                probibilaties = new[] { .6, .4 };
                yield return new object[] { objects, probibilaties, rounds };

                // Somewhat More Complicated test
                objects = new object[] { 'a', 'b' };
                probibilaties = new[] { 1.0, 0.0 };
                yield return new object[] { objects, probibilaties, rounds };

                // Somewhat More Complicated test
                objects = new object[] { 'a', 'b' };
                probibilaties = new[] { 0.0, 1.0 };
                yield return new object[] { objects, probibilaties, rounds };

                // Complicated test
                objects = new object[] { 'a', 'a', 'b' };
                probibilaties = new[] { .5, .5, 0 };
                yield return new object[] { objects, probibilaties, rounds };

                // Complicated test
                objects = new object[] { new System.Random(), new Exception() };
                probibilaties = new[] { 0.5, 0.5 };
                yield return new object[] { objects, probibilaties, rounds };
            }
        }
    }
}
