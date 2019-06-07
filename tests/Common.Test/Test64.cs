// A knight's tour is a sequence of moves by a knight on a chessboard such that all squares are visited once.
// Given N, write a function to return the number of knight's tours on an N by N chessboard.

using NUnit.Framework;

namespace Common.Test
{
    public class Test64
    {
        [SetUp]
        public void Setup() { }
        [Test]
        public void Problem64()
        {
            //-- Arrange
            var expected = 26534728821064;

            //-- Act
            var actual = Solution64.KnightTours().Count();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}