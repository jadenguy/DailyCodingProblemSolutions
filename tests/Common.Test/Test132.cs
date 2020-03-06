// Design and implement a HitCounter class that keeps track of requests (or hits). It should support the following operations:
// •	record(timestamp): records a hit that happened at timestamp
// •	total(): returns the total number of hits recorded
// •	range(lower, upper): returns the number of hits that occurred between timestamps lower and upper (inclusive)
// Follow-up: What if our system has limited memory?

using System.Collections;
using NUnit.Framework;

namespace Common.Test
{
    public class Test132
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem132()
        {
            //-- Arrange
            var expected = new object();
            var counter = new Solution132.HitCounter();
            
            //-- Act
            counter.Hit(System.DateTime.Now);
            var actual = counter;
            

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { };
            }
        }
    }
}