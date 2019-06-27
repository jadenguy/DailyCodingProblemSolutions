// The edit distance between two strings refers to the minimum number of character insertions, deletions, and substitutions required to change one string to the other. For example, the edit distance between “kitten” and “sitting” is three: substitute the “k” for “s”, substitute the “e” for “i”, and append a “g”.
// Given two strings, compute the edit distance between them.

using NUnit.Framework;

namespace Common.Test
{
    public class Test31
    {

        [SetUp]
        public void Setup() { }
        [Test]
        [TestCase("abc","cba",2)]
        [TestCase("kitten", "sitting", 3)]
        [TestCase("sitting", "kitten", 3)]
        [TestCase(".XX.","..",2)]
        [TestCase("..",".XX.",2)]
        [TestCase(".X.X","..",2)]
        [TestCase("..",".X.X",2)]
        [TestCase("X.X.","..",2)]
        [TestCase("..","X.X.",2)]
        public void Problem31(string textA, string textB, int result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            var actual = Solution31.MeasureDistance(textA, textB);

            //-- Assert        
            Assert.AreEqual(actual, expected);
        }
    }
}