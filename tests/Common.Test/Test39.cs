// Conway's Game of Life takes place on an infinite two-dimensional board of square cells. Each cell is either dead or alive, and at each tick, the following rules apply:
// •	Any live cell with less than two live neighbours dies.
// •	Any live cell with two or three live neighbours remains living.
// •	Any live cell with more than three live neighbours dies.
// •	Any dead cell with exactly three live neighbours becomes a live cell.
// A cell neighbours another cell if it is horizontally, vertically, or diagonally adjacent.
// Implement Conway's Game of Life. It should be able to be initialized with a starting list of live cell coordinates and the number of steps it should run for. Once initialized, it should print out the board state at each step. Since it's an infinite board, print out only the relevant coordinates, i.e. from the top-leftmost live cell to bottom-rightmost live cell.
// You can represent a live cell with an asterisk (*) and a dead cell with a dot (.).


using Common.Board;
using Common.Extensions;
using NUnit.Framework;
using System.Collections.Generic;

namespace Common.Test
{
    public class Test039
    {
        List<HashSet<(int, int)>> initialBoards = new List<HashSet<(int, int)>>();
        List<GameOfLifeBoard> resultBoard = new List<GameOfLifeBoard>();
        ConwayRules rules = new ConwayRules();
        [SetUp]
        public void Setup()
        {
            initialBoards.Add(new HashSet<(int, int)>() { (1, 1), (1, 0), (0, 0), (0, 1) });
        }
        // [TearDown]
        // public void TearDown() { }
        [Test]
        [TestCase(0, 10)]
        public void Problem039(int boardIndex, int runs)
        {
            //-- Arrange
            // var expected = resultBoard[boardIndex];

            //-- Act
            var actual = Solution39.PlayConway(initialBoards[boardIndex], rules, runs);
            var i = 0;
            foreach (var item in actual.StreamSlowly(100))
            {
                System.Diagnostics.Debug.WriteLine(i);
                System.Diagnostics.Debug.WriteLine(item.Display()); ;
                i++;
            }

            //-- Assert
            // Assert.AreEqual(expected, actual);
        }
    }
}