// Given a function f, and N return a debounced f of N milliseconds.
// That is, as long as the debounced f continues to be invoked, f itself will not be called for N milliseconds.

using System;
using NUnit.Framework;

namespace Common.Test
{
    public class Test105
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        // [Test]
        // [TestCase()]
        public void Problem105(Action<int> func, int time)
        {
            //-- Arrange
            var expected = time;

            //-- Act
            var actual = Solution105.Debounce(func, time);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
