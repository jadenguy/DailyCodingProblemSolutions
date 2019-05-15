// You are given an M by N matrix consisting of booleans that represents a board. Each True boolean represents a wall. Each False boolean represents a tile you can walk on.
// Given this matrix, a start coordinate, and an end coordinate, return the minimum number of steps required to reach the end coordinate from the start. If there is no possible path, then return null. You can move up, left, down, and right. You cannot move through walls. You cannot wrap around the edges of the board.
// For example, given the following board:
// [[f, f, f, f],
// [t, t, f, t],
// [f, f, f, f],
// [f, f, f, f]]
// and start = (3, 0) (bottom left) and end = (0, 0) (top left), the minimum number of steps required to reach the end is 7, since we would need to go through (1, 2) because there is a wall everywhere else on the second row.

using System;
using NUnit.Framework;

namespace Common.Test
{
    public class Test23
    {


        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void Problem23()
        {
            //-- Arrange
            var t = true;
            var f = false;
            var grid = new bool[,] {{f, f, f, f},
                                    {t, t, f, t},
                                    {f, f, f, f},
                                    {f, f, f, f}};
            var start = (3, 0);
            var end = (0, 0);
            var expected = 7;

            //-- Act
            var actual = Solution23.AStarSearchStepCount(grid, start, end);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}