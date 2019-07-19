// Run-length encoding is a fast and simple method of encoding strings. The basic idea is to represent repeated successive characters as a single count and character. For example, the string "AAAABBBCCDAA" would be encoded as "4A3B2C1D2A".
// Implement run-length encoding and decoding. You can assume the string to be encoded have no digits and consists solely of alphabetic characters. You can assume the string to be decoded is valid.

using NUnit.Framework;

namespace Common.Test
{
    public class Test029
    {

        string encoded = "4A3B2C1D2A10X";
        string decoded = "AAAABBBCCDAAXXXXXXXXXX";
        [SetUp]
        public void Setup() { }
        [Test]
        public void Problem29Encode()
        {
            //-- Arrange
            var expected = encoded;

            //-- Act
            var actual = Solution029.Encode(decoded);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem29Decode()
        {
            //-- Arrange
            var expected = decoded;

            //-- Act
            var actual = Solution029.Decode(encoded);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}