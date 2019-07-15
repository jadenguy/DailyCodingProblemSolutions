// Given the mapping a = 1, b = 2, ... z = 26, and an encoded message, count the number of ways it can be decoded.
// For example, the message '111' would give 3, since it could be decoded as 'aaa', 'ka', and 'ak'.
// You can assume that the messages are decodeable. For example, '001' is not allowed.


using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test007
    {

        [Test]
        [TestCase("1010", 1)]
        [TestCase("111", 3)]
        [TestCase("222", 3)]
        [TestCase("2727", 1)]
        [TestCase("1111", 5)]
        [TestCase("999", 1)]
        // [TestCase("1234567891011121314151617181920212223242526", 3)]
        public void Problem7(string code, int count)
        {
            //-- Arrange
            var expected = count;

            //-- Act
            var actual = Solution7.DecodeCount(code);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}