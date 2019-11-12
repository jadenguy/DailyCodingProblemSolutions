// Using a read7() method that returns 7 characters from a file, implement readN(n) which reads n characters.
// For example, given a file with the content “Hello world”, three read7() returns “Hello w”, “orld” and then “”.

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test082
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem082()
        {
            //-- Arrange
            var file = new Solution082.File("Hello World");
            var expected = "Hello World";

            //-- Act
            const int n = 11;
            var actual = Solution082.ReadN(file, n);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}