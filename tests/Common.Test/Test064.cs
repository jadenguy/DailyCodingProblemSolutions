// A knight's tour is a sequence of moves by a knight on a chessboard such that all squares are visited once.
// Given N, write a function to return the number of knight's tours on an N by N chessboard.

using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test064
    {
        // [SetUp] public void Setup() { }
        [Test]
        [TestCase(1, 0, 0, 1)]
        [TestCase(2, 0, 0, 0)]
        [TestCase(5, 1, 1, 56)]
        [TestCase(5, 2, 2, 64)]
        public void OnePositionKnightTour(int size, int startX, int startY, int answers)
        {
            //-- Arrange
            var expected = answers;

            //-- Act
            var watch = System.Diagnostics.Stopwatch.StartNew();
            int[][,] boards = Solution064.KnightTourFrom(Solution064.BlankBoard(size), (startX, startY), 1).ToArray();
            System.Diagnostics.Debug.WriteLine(watch.ElapsedMilliseconds);
            System.Console.WriteLine(watch.ElapsedMilliseconds);

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
            int[][,] boards = Solution064.KnightTourFrom(new int[3, 4], (0, 0), 1).ToArray();

            var actual = boards.Length;

            //-- Assert
            Assert.GreaterOrEqual(actual, 1);
        }
        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 0)]
        // [TestCase(5,1728)] // un-check if you want to see 18 seconds pass you by, I could save time if I figured out the number of reflections, etc.
        public void Problem064(int boardSize, int results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var actual = Solution064.KnightToursEveryCell(boardSize).Count();
            System.Diagnostics.Debug.WriteLine(watch.ElapsedMilliseconds);
            System.Console.WriteLine(watch.ElapsedMilliseconds);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase(1, 1, 0, 0, 1)]
        [TestCase(1, 2, 0, 0, 2)]
        [TestCase(2, 3, 0, 0, 4)]
        [TestCase(2, 3, 0, 1, 2)]
        [TestCase(3, 3, 0, 1, 4)]
        [TestCase(5, 6, 1, 1, 4)]
        [TestCase(2, 6, 0, 0, 4)]
        [TestCase(9, 9, 4, 4, 1)]
        
        [TestCase(9, 9, 1, 2, 8)]
        [TestCase(10, 10, 1, 2, 8)]
        public void PickArrayElements(int dim0, int dim1, int x, int y, int repetitions)
        //  I could save between 2 and 8 rounds of calculation by returning the set of result families that could be rotated and flipped.
        {
            //-- Arrange
            var height = (dim0 < dim1) ? dim0 : dim1;
            var width = (dim0 > dim1) ? dim0 : dim1;
            var expectedAtLocation = repetitions;
            var expectedTotal = height * width;
            //-- Act

            var selected = Solution064.SelectElements(height, width);
            var selectionSum = 0;
            foreach (var item in selected)
            {
                selectionSum += item;
            }
            selected.PrintBoard();
            int actual = selected[x, y];

            //-- Assert
            Assert.AreEqual(expectedAtLocation, actual);
            Assert.AreEqual(expectedTotal, selectionSum);
        }
    }
}