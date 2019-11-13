// Using a read7() method that returns 7 characters from a file, implement readN(n) which reads n characters.
// For example, given a file with the content “Hello world”, three read7() returns “Hello w”, “orld” and then “”.

using NUnit.Framework;

namespace Common.Test
{
    public class Test082
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase("1234567", 6, "123456")]
        [TestCase("1234567", 7, "1234567")]
        [TestCase("1234567", 8, "1234567")]
        [TestCase("Hello World", 13, "Hello World")]
        public void Problem082(string content = "Hello World", int n = 11, string results = "Hello World")
        {
            //-- Arrange
            var file = new Solution082.File(content);
            var expected = results;

            //-- Act
            var actual = Solution082.ReadN(file, n);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}