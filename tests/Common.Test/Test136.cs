// Given an N by M matrix consisting only of 1's and 0's, find the largest rectangle containing only 1's and return its area.
// For example, given the following matrix:
// [[1, 0, 0, 0],
//  [1, 0, 1, 1],
//  [1, 0, 1, 1],
//  [0, 1, 0, 0]]
// Return 4.

using System.Collections;
using Common.Extensions;
using Common.Node;
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
            Common.Extensions.CollectionExtensions.Print(matrix, n => n ? "1" : "0").WriteHost("Matrix",true,true);

            //-- Act
            var actual = Solution136.LargestRectangle(matrix);
            actual.Value.WriteHost("Actual");

            //-- Assert
            Assert.AreEqual(expected, actual.Value);
        }
        class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                var matrix = new bool[,] {
                        {true, false, false, false},
                        {true, false, true, true},
                        {true, false, true, true},
                        {false, true, false, false}
                    };
                var area = 4;
                yield return new object[] { matrix, area };
            }
        }
    }
}