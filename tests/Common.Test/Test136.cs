// Given an N by M matrix consisting only of 1's and 0's, find the largest rectangle containing only 1's and return its area.
// For example, given the following matrix:
// [[1, 0, 0, 0],
//  [1, 0, 1, 1],
//  [1, 0, 1, 1],
//  [0, 1, 0, 0]]
// Return 4.

using System.Collections;
using System.Linq;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test136
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem136(bool[,] matrix, int area)
        {
            //-- Arrange
            var expected = area;
            matrix.Print(n => n ? "XX" : "__").WriteHost("Matrix");
            area.WriteHost("Wanted");

            //-- Act
            var enumerable = Solution136.LargestRectangle(matrix);
            var actual = (!enumerable.Any()) ? 0 : enumerable.Max(g => (g.x1 - g.x0) * (g.y1 - g.y0));
            actual.WriteHost("Actual");

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                bool[,] matrix;
                int area;

                // 0
                matrix = new bool[,] {
                        {true, false },
                        { false, false }
                    };
                area = 1;
                yield return new object[] { matrix, area };
                // 0
                matrix = new bool[,] {
                        { false, true },
                        { false, false }
                    };
                area = 1;
                yield return new object[] { matrix, area };
                // 0
                matrix = new bool[,] {
                        { false, false },
                        { true, false }

                    };
                area = 1;
                yield return new object[] { matrix, area };
                // 0
                matrix = new bool[,] {
                        {true, false},
                        { false, false}
                    };
                area = 1;
                yield return new object[] { matrix, area };

                // 1
                matrix = new bool[,] {
                        {true, false, false, false},
                        {true, false, true, true},
                        {true, false, true, true},
                        {false, true, false, false}
                    };
                area = 4;
                yield return new object[] { matrix, area };

            }
        }
    }
}