// Implement a job scheduler which takes in a function f and an integer n, and calls f after n milliseconds.

using System;
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
            var delay = 200;
            var expectedInstant = 0;
            var expectedAwaited = delay;
            Action action;
            var stopwatch = Stopwatch.StartNew();
            action = () => System.Console.WriteLine("TaskDone");
            int DeltaInstant = 50;
            int DeltaDelayed = delay / 10;

            //-- Act
            var awaiter = Solution010.TaskScheduler(action, delay);
            var actualInstant = stopwatch.ElapsedMilliseconds;
            await awaiter;
            var actualAwaited = stopwatch.ElapsedMilliseconds;

            //-- Assert
            Assert.AreEqual(expectedInstant, actualInstant, DeltaInstant);
            Assert.AreEqual(expectedAwaited, actualAwaited, DeltaDelayed);
        }
    }
}