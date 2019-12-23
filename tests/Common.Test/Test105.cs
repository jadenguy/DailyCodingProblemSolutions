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
        [Test]
        public void Problem105()
        {
            //-- Arrange
            var expected = 0;
            Func<int, int> func = e => e;

            //-- Act
            int milliseconds = 500;
            int bounces = 10;
            var awaiter = Solution105.Debounce(func, 0, milliseconds); ;
            for (int i = 1; i < bounces; i++) { awaiter = Solution105.Debounce(func, i, milliseconds); }
            var actual = awaiter.GetAwaiter().GetResult();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}