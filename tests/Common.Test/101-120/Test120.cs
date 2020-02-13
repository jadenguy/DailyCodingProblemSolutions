// Implement the singleton pattern with a twist. First, instead of storing one instance, store two instances. And in every even call of getInstance(), return the first instance and in every odd call of getInstance(), return the second instance.

using System.Linq;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test120
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem120()
        {
            //-- Arrange
            var rand = new System.Random();
            var checks = rand.Next(100, 200);
            var expectedA = rand.Next(0, 10);
            var expectedB = rand.Next(0, 10);
            var expected = checks * expectedA + checks * expectedB;
            checks.WriteHost("How many rounds");
            expectedA.WriteHost("Value A");
            expectedB.WriteHost("Value B");
            expected.WriteHost("Sum of rounds");

            //-- Act
            var nChecks = SetAndGetInstance(expectedA, expectedB, out var actualA, out var actualB, checks * 2);
            var actual = nChecks.Sum(n => n);
            actualA.WriteHost("A");
            actualB.WriteHost("B");
            actual.WriteHost("Sum");

            //-- Assert
            Assert.AreEqual(expectedA, actualA);
            Assert.AreEqual(expectedB, actualB);
            Assert.AreEqual(expected, actual);
        }
        [System.Diagnostics.DebuggerStepThrough]
        private static ParallelQuery<int> SetAndGetInstance(int expectedA, int expectedB, out int actualA, out int actualB, int Count = 100)
        {
            (Solution120.GetInstance, Solution120.GetInstance) = (expectedA, expectedB);
            (actualA, actualB) = (Solution120.GetInstance, Solution120.GetInstance);
            return Enumerable.Range(0, Count).AsParallel().Select(n => Solution120.GetInstance);
        }
    }
}