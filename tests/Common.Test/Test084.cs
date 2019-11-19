// Given a matrix of 1s and 0s, return the number of "islands" in the matrix. A 1 represents land and 0 represents water, so an island is a group of 1s that are neighboring whose perimeter is surrounded by water.
// For example, this matrix has 4 islands.
// 1 0 0 0 0
// 0 0 1 1 0
// 0 1 1 0 0
// 0 0 0 0 0
// 1 1 0 0 1
// 1 1 0 0 1

using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test084
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase()]
        public void Problem084(string[] input = null, int results = 4)
        {
            //-- Arrange
            var expected = results;
            if (input == null)
            {
                input = new string[] {
                    "10000",
                    "00110",
                    "01100",
                    "00000",
                    "11001",
                    "11101"
                };
            }
            Solution084.IslandOcean board = Solution084.StringArrayToGrid(input);

            //-- Act
            var actual = Solution084.ListIslands(board);

            // //-- Assert
            Assert.AreEqual(expected, actual.Count());
        }
    }
}