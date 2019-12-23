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
        public void Problem105Debounce()
        {
            //-- Arrange
            var expected = 0;
            int milliseconds = 100;
            int bounces = 10;
            Func<int, int> func = e => e;

            //-- Act
            var awaiter = Solution105.Debounce(func, 0, milliseconds);
            for (int i = 1; i < bounces; i++) { awaiter = Solution105.Debounce(func, i, milliseconds); }
            var actual = awaiter.GetAwaiter().GetResult();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem105AfterDebounce()
        {
            //-- Arrange
            var expected = 1;
            Func<int, int> func = e => e;
            int milliseconds = 100;

            //-- Act
            var awaiter = Solution105.Debounce(func, 0, milliseconds);
            System.Threading.Tasks.Task.Delay(101);
            awaiter = Solution105.Debounce(func, 1, milliseconds);
            var actual = awaiter.GetAwaiter().GetResult();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}