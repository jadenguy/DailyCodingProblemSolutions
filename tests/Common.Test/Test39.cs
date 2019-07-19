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
using System.Linq;

namespace Common.Test
{
    public class Test039
    {
        List<GameOfLifeBoard> initialBoards = new List<GameOfLifeBoard>();
        List<int> iterations = new List<int>();
        List<GameOfLifeBoard> resultBoards = new List<GameOfLifeBoard>();
        ConwayRules rules = new ConwayRules(3, 3, 2, 3);
        [SetUp]
        public void Setup()
        {
            initialBoards.Add(new GameOfLifeBoard(new (int, int)[] { (1, 1), (1, 0), (0, 0), (0, 1), (2, 1) }));
            resultBoards.Add(new GameOfLifeBoard(new (int, int)[] { }));
            iterations.Add(10);
            initialBoards.Add(new GameOfLifeBoard(new (int, int)[] { (1, 2), (2, 3), (3, 1), (3, 2), (3, 3) }));
            resultBoards.Add(new GameOfLifeBoard(new (int, int)[] { (26, 27), (27, 28), (28, 26), (28, 27), (28, 28) }));
            iterations.Add(100);
            initialBoards.Add(new GameOfLifeBoard(new (int, int)[] { (1, 1), (1, 2), (1, 3) }));
            resultBoards.Add(new GameOfLifeBoard(new (int, int)[] { (1, 1), (1, 2), (1, 3) }));
            iterations.Add(1000);
            initialBoards.Add(new GameOfLifeBoard(new (int, int)[] { (1, 1), (1, 0), (0, 0), (0, 1) }));
            resultBoards.Add(new GameOfLifeBoard(new (int, int)[] { (0, 0), (0, 1), (1, 0), (1, 1) }));
            iterations.Add(5);
        }
        // [TearDown]
        // public void TearDown() { }
        // [Test]
        public void TestRules()
        {
            for (int i = 0; i < 8; i++)
            {
                System.Diagnostics.Debug.WriteLine(rules.Apply(i, true), $"{i} and is alive");
            }
            for (int i = 0; i < 8; i++)
            {
                System.Diagnostics.Debug.WriteLine(rules.Apply(i, false), $"{i} and is dead");
            }
        }
        [Test]

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Problem039(int boardIndex)
        {
            //-- Arrange
            var runs = iterations[boardIndex];
            var expected = resultBoards[boardIndex];
            GameOfLifeBoard initial = initialBoards[boardIndex];

            //-- Act
            var stream = Solution39.PlayConway(initial, rules, runs).Select(b => new GameOfLifeBoard(b));
            // var i = 0;
            // foreach (var item in stream.StreamSlowly(100))
            // {
            //     System.Diagnostics.Debug.WriteLine(i);
            //     System.Diagnostics.Debug.WriteLine(item.Display()); ;
            //     i++;
            // }
            var actual = stream.Last();
            System.Console.WriteLine(actual.Display());
            System.Diagnostics.Debug.WriteLine(actual.Display());

            //-- Assert

            Assert.IsTrue(expected.SetEquals(actual), "You lost at the game of life");
        }
    }
}