// A knight's tour is a sequence of moves by a knight on a chessboard such that all squares are visited once.
// Given N, write a function to return the number of knight's tours on an N by N chessboard.

using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test064
    {
        [SetUp]
        public void Setup() { }
        [Test]
        [TestCase(5, 2, 2, 64)]
        [TestCase(5, 1, 1, 56)]
        [TestCase(1, 0, 0, 1)]
        public void OnePositionKnightTour(int size, int startX, int startY, int answers)
        {
            //-- Arrange
            var expected = answers;

            //-- Act
            int[][,] boards = Solution064.KnightTourFrom(Solution064.BlankBoard(size), (startX, startY), 1).ToArray();

            var actual = boards.Length;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void OnePositionRectangularKnightTour()
        {
            //-- Arrange
            // var expected = answers;

            //-- Act
            int[][,] boards = Solution064.KnightTourFrom(new int[3,4], (0, 0), 1).ToArray();

            var actual = boards.Length;

            //-- Assert
            Assert.GreaterOrEqual(actual,1);
        }
        [Test]
        [TestCase(1,1)]
        [TestCase(2,0)]
        // [TestCase(5,1728)]
        public void Problem064(int boardSize, int results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            // var watch = System.Diagnostics.Stopwatch.StartNew();
            var actual = Solution064.KnightToursEveryCell(boardSize).Count();
            // System.Diagnostics.Debug.WriteLine(watch.ElapsedMilliseconds);
            // System.Console.WriteLine(watch.ElapsedMilliseconds);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        // [Test]
        // [TestCase(4, 28)]
        // [TestCase(5, 25)]
        // [TestCase(6, 36)]
        // [TestCase(7, 49)]
        public void PickArrayElements(int size, int square) 
        //  I could save between 2 and 8 rounds of calculation by returning the set of result families that could be rotated and flipped.
        {
            var selected = Solution064.SelectElements(size);
            var selectionSum = 0;
            foreach (var item in selected)
            {
                selectionSum += item;
            }
            selected.PrintBoard();
            Assert.AreEqual(size * size, square, $"Your TestCase is wrong, k = {square}, should be {size * size}.");
            Assert.AreEqual(square, selectionSum);
        }
    }
}