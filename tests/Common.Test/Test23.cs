// You are given an M by N matrix consisting of booleans that represents a board. Each True boolean represents a wall. Each False boolean represents a tile you can walk on.
// Given this matrix, a start coordinate, and an end coordinate, return the minimum number of steps required to reach the end coordinate from the start. If there is no possible path, then return null. You can move up, left, down, and right. You cannot move through walls. You cannot wrap around the edges of the board.
// For example, given the following board:
// [[f, f, f, f],
// [t, t, f, t],
// [f, f, f, f],
// [f, f, f, f]]
// and start = (3, 0) (bottom left) and end = (0, 0) (top left), the minimum number of steps required to reach the end is 7, since we would need to go through (1, 2) because there is a wall everywhere else on the second row.

using System;
using Common.Board;
using NUnit.Framework;

namespace Common.Test
{
    public class Test023
    {
        [SetUp]
        public void Setup() { }
        [Test]
        public void CellGTest()
        {
            var x = new Cell(0, 1);
            x.Parent = new Cell(0, 0);
            Assert.AreEqual(1, x.G);
            Assert.AreEqual(0, x.Parent.G);
        }
        [Test]
        public void CellFTest()
        {
            var x = new Cell(0, 1, (1, 1));
            x.Parent = new Cell(0, 0, (1, 1));
            System.Diagnostics.Debug.WriteLine(x);
            Assert.AreEqual(2, x.F);
            Assert.AreEqual(2, x.Parent.F);
        }
        [Test]
        public void CellEquitable()
        {
            var x = new Cell(0, 0);
            var y = new Cell(0, 0);
            Assert.AreEqual(x, y);
        }
        [Test]
        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(3, 0, 0, 0, 7)]
        [TestCase(17, 0, 0, 0, 67)]
        public void Problem23(int startX, int startY, int endX, int endY, int length)
        {
            //-- Arrange
            var t = true;
            var f = false;
            var grid = new bool[,] {{f,f,f,f,f,f,f,f,f,f,f,f,f,f},
                                    {t,t,f,t,t,t,t,t,t,t,t,f,f,f},
                                    {f,f,f,f,f,f,f,f,f,f,f,f,f,f},
                                    {f,t,f,f,f,f,f,f,f,f,f,f,f,f},
                                    {f,t,f,f,f,f,f,f,f,f,f,f,f,f},
                                    {f,t,f,f,f,f,f,f,f,f,f,f,f,f},
                                    {f,t,f,f,f,f,f,f,t,t,t,t,f,f},
                                    {f,t,f,f,f,f,f,f,t,f,f,t,f,f},
                                    {f,t,f,f,f,f,f,f,t,f,f,t,f,f},
                                    {f,t,f,f,f,f,f,f,t,f,f,t,f,f},
                                    {f,t,f,f,f,f,f,f,t,f,f,t,f,f},
                                    {f,t,f,f,f,f,f,f,t,f,f,t,f,f},
                                    {f,t,f,f,f,f,f,f,t,f,f,t,f,f},
                                    {f,t,f,f,f,f,f,f,t,f,f,t,f,f},
                                    {t,t,f,f,t,t,t,t,t,f,f,t,f,f},
                                    {f,t,f,f,t,f,f,f,f,f,f,t,f,f},
                                    {f,t,f,f,t,f,f,f,f,f,f,t,f,f},
                                    {f,t,f,f,t,f,f,f,f,f,f,t,f,f},
                                    {f,t,f,f,t,f,t,t,t,t,f,t,f,f},
                                    {f,t,f,f,t,f,t,f,f,f,f,t,f,f},
                                    {f,t,t,t,t,f,t,f,f,f,f,t,f,f},
                                    {f,f,f,f,f,f,t,f,f,f,f,t,f,f},
                                    {f,f,f,f,f,f,t,f,t,t,t,t,f,f},
                                    {f,f,f,f,f,f,t,f,f,f,f,f,f,f},
                                    {f,f,f,f,f,f,t,f,f,f,f,f,f,f},
                                    {f,f,f,f,f,f,t,f,f,f,f,f,f,f},
                                    {f,f,f,f,f,f,t,f,f,f,f,f,f,f},
                                    {f,f,f,f,f,f,t,f,f,f,f,f,f,f}};
            var expected = length;

            //-- Act
            var actual = Solution23.AStarSearchStepCount(grid, (startX, startY), (endX, endY)).Length - 1;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}