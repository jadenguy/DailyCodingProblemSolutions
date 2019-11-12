// There is an N by M matrix of zeroes. Given N and M, write a function to count the number of ways of starting at the top-left corner and getting to the bottom-right corner. You can only move right or down.
// For example, given a 2 by 2 matrix, you should return 2, since there are two ways to get to the bottom-right:
// •	Right, then down
// •	Down, then right
// Given a 5 by 5 matrix, there are 70 ways to get to the bottom-right.

// Pascal's Triangle?

using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test062
    {
        [SetUp]
        public void Setup() { }
        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(5, 70)]
        public void Problem062Pascal(int arraySize, int result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            var row = Solution062.Pascal(arraySize + arraySize - 1).Last(); // build pascal's triangle
            var actual = row.Skip(arraySize - 1).First(); // select the center box of the triangle, also known as the number of ways to reach this point.

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(5, 70)]
        public void Problem062(int arraySize, int result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            var table = Solution062.As2DArray(arraySize);
            var actual = table[arraySize - 1, arraySize - 1]; // select the center box of the triangle, also known as the number of ways to reach this point.

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}