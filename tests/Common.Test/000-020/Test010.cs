// Implement a job scheduler which takes in a function f and an integer n, and calls f after n milliseconds.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Common.Test
{
    public class Test010
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]

        public async Task Problem10Async()
        {
            //-- Arrange
            var expectedInstant = 0;
            var expectedAwaited = 1000;
            Action action;
            var delay = 1;
            var stopwatch = Stopwatch.StartNew();
            action = () => System.Console.WriteLine("TaskDone");

            //-- Act
            var awaiter = Solution010.TaskScheduler(action, delay);
            var actualInstant = stopwatch.ElapsedMilliseconds;
            await awaiter;
            var actualAwaited = stopwatch.ElapsedMilliseconds;

            //-- Assert
            Assert.AreEqual(expectedInstant, actualInstant, 10);
            Assert.AreEqual(expectedAwaited, actualAwaited, 10);
        }
    }
}