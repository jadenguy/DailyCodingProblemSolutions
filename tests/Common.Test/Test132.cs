// Design and implement a HitCounter class that keeps track of requests (or hits). It should support the following operations:
// •	record(timestamp): records a hit that happened at timestamp
// •	total(): returns the total number of hits recorded
// •	range(lower, upper): returns the number of hits that occurred between timestamps lower and upper (inclusive)
// Follow-up: What if our system has limited memory?

using NUnit.Framework;

namespace Common.Test
{
    public class Test132
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem132()
        {
            //-- Arrange
            const int hitCount = 100;
            var expectedTotal = hitCount;
            var expectedYesterday = 24;
            var counter = new Solution132.HitCounter();
            var now = System.DateTimeOffset.UtcNow.ToLocalTime();
            var lower = now.AddDays(-2).AddSeconds(1);
            var upper = now.AddDays(-1);

            //-- Act
            for (int i = 0; i < hitCount; i++)
            {
                var v = now.AddHours(-i);
                counter.Record(v);
            }
            var actualTotal = counter.Total();
            var actualYesterday = counter.Range(lower, upper);

            // //-- Assert
            Assert.AreEqual(expectedTotal, actualTotal);
            Assert.AreEqual(expectedYesterday, actualYesterday);
        }
    }
}