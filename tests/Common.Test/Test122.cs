// You are given a 2-d matrix where each cell represents number of coins in that cell. Assuming we start at matrix[0][0], and can only move right or down, find the maximum number of coins you can collect by the bottom right corner.
// For example, in this matrix
// 0 3 1 1
// 2 0 0 4
// 1 5 3 1
// The most we can collect is 0 + 2 + 1 + 5 + 3 + 1 = 12 coins.

using System.Collections;
using System.Linq;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test122
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases))]
        public void Problem122(int[,] input, int result)
        {
            //-- Arrange
            var expected = result;

            input.Print().WriteHost("Array");
            expected.WriteHost("Best Score");

            //-- Act
            var actual = Solution122.BestPathScoreNaive(input);
            actual.WriteHost("Actual");

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        class Cases : IEnumerable
        {
            private const int rangeStart = 0;
            private const int rangeLength = 3;
            public IEnumerator GetEnumerator()
            {
                int[,] array;
                int maxPath;
                var rand = new System.Random();

                array = new int[,] {{0,3,1,1},
                                    {2,0,0,4},
                                    {1,5,3,1}};
                maxPath = 12;
                yield return new object[] { array, maxPath };

                const int max = 5;
                const int len = max + 1;
                array = new int[len, len];
                array[rand.Next(0, max), rand.Next(0, max)] = 1;
                maxPath = 1;
                yield return new object[] { array, maxPath };

                array = new int[len, len];
                array[rand.Next(0, max), rand.Next(0, max)] = -1;
                maxPath = (array.Cast<int>()).Max();
                yield return new object[] { array, maxPath };
            }
        }
    }
}
