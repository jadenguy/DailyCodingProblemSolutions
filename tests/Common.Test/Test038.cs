// You have an N by N board.Write a function that, given N, returns the number of possible arrangements of the board where N queens can be placed on the board without threatening each other, i.e.no two queens share the same row, column, or diagonal.

using NUnit.Framework;
using System.Linq;

namespace Common.Test
{
    public class Test038
    {
        // [SetUp]
        // public void Setup() { }
        // [TearDown]
        // public void TearDown() { }
        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 0)]
        [TestCase(3, 0)]
        [TestCase(4, 2)]
        [TestCase(5, 10)]
        [TestCase(6, 4)]
        [TestCase(7, 40)]
        [TestCase(8, 92)]
        [TestCase(9, 352)]
        [TestCase(10, 724)]
        public void Problem038(int n, int results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            var actual = Solution038.NQueens(n).Count();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}