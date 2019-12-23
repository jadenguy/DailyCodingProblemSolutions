// Given a function f, and N return a debounced f of N milliseconds.
// That is, as long as the debounced f continues to be invoked, f itself will not be called for N milliseconds.

using System;
using System.Threading;
using NUnit.Framework;

namespace Common.Test
{
    public class Test105
    {
        private const int milliseconds = 50;

        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem105Debounce()
        {
            //-- Arrange
            var expected = 0;
            int bounces = 10;
            Func<int, int> func = e => e;

            //-- Act
            TaskWaiter awaiter = null;
            for (int i = 0; i < bounces; i++) { awaiter = Solution105.Debounce(func, i, milliseconds); }
            var actual = awaiter.GetAwaiter().GetResult();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem105DebounceFast()
        {
            //-- Arrange
            var expected = 0;
            int bounces = 10;
            Func<int, int> func = e => e;

            //-- Act
            TaskWaiter awaiter = null;
            for (int i = 0; i < bounces; i++)
            {
                awaiter = Solution105.Debounce(func, i, milliseconds, true);
                Thread.Sleep(10);
            }
            var actual = awaiter.GetAwaiter().GetResult();

            // //-- Assert
            Assert.AreNotEqual(expected, actual);
        }
        [Test]
        public void Problem105AfterDebounce()
        {
            //-- Arrange
            var expected = 1;
            Func<int, int> func = e => e;

            //-- Act
            var awaiter = Solution105.Debounce(func, 0, milliseconds);
            Thread.Sleep(milliseconds + 10);
            awaiter = Solution105.Debounce(func, 1, milliseconds);
            var actual = awaiter.GetAwaiter().GetResult();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}