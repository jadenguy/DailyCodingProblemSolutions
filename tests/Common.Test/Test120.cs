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
            var expectedA = 1;
            var expectedB = 2;
            var sequence = Enumerable.Range(0, 10);

            //-- Act
            SetAndGetInstance(expectedA, expectedB, out var actualA, out var actualB);

            //-- Assert
            Assert.AreEqual(expectedA, actualA);
            Assert.AreEqual(expectedB, actualB);
        }
        [System.Diagnostics.DebuggerStepThrough]
        private static void SetAndGetInstance(int expectedA, int expectedB, out int actualA, out int actualB)
        {
            (Solution120.GetInstance, Solution120.GetInstance) = (expectedA, expectedB);
            (actualA, actualB) = (Solution120.GetInstance, Solution120.GetInstance);
        }
    }
}
