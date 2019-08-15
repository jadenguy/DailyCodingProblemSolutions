// Sudoku is a puzzle where you're given a partially-filled 9 by 9 grid with digits. The objective is to fill the grid with the constraint that every row, column, and box (3 by 3 subgrid) must contain all of the digits from 1 to 9.
// Implement an efficient sudoku solver.


using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test054
    {
        private const string fullSquare = "123456789";
        private const string partialSquare = "123456780";
        private const string invalidSquare = "111111111";
        private const string emptySquare = "000000000";
        private const string emptyBoard = "000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        private const string initialBoard = "003020600900305001001806400008102900700000008006708200002609500800203009005010300";
        private const string completeBoard = "483921657967345821251876493548132976729564138136798245372689514814253769695417382";
        private const string invalidBoard = "111111111111111111111111111111111111111111111111111111111111111111111111111111111";

        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(fullSquare, true)]
        [TestCase(partialSquare, true)]
        [TestCase(emptySquare, true)]
        [TestCase(invalidSquare, false)]
        public void Problem054IsSquareValid(string square, bool valid)
        {
            //-- Arrange
            var expected = valid;

            //-- Act
            bool actual = Solution054.ValidateSquare(square);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase(initialBoard, false)]
        [TestCase(completeBoard, true)]
        [TestCase(invalidBoard, false)]
        public void Problem054IsBoardValid(string square, bool valid)
        {
            //-- Arrange
            var expected = valid;

            //-- Act
            bool actual = Solution054.ValidateBoard(square);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase(emptySquare, emptyBoard)]
        [TestCase(invalidSquare, invalidBoard)]
        public void Problem054SampleBoard(string square, string board)
        {
            //-- Arrange
            var expectedSquare = square;
            var expectedSquareCount = 27;

            //-- Act
            var actual = Solution054.BoardToSquares(board).ToArray();

            // //-- Assert
            Assert.AreEqual(expectedSquareCount, actual.Length, "wrong number of samples returned");
            if (expectedSquareCount == actual.Length)
            {
                for (int i = 0; i < expectedSquareCount; i++)
                {
                    Assert.AreEqual(expectedSquare, actual[i]);
                }
            }
        }
    }
}