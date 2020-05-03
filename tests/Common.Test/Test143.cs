// Given a pivot x, and a list lst, partition the list into three parts.
// *	The first part contains all elements in lst that are less than x
// *	The second part contains all elements in lst that are equal to x
// *	The third part contains all elements in lst that are larger than x
// Ordering within a part can be arbitrary.

using System.Linq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Common.Test
{
    public class Test143
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases143))]
        public void Problem143(int x, int[] lst, int[][] results)
        {
            //-- Assert
            var expected = results.Select(n => new HashSet<int>(n)).ToArray();

            //-- Arrange
            var actual = Solution143.Partition(x, lst).Select(n => new HashSet<int>(n)).ToArray();

            //-- Act
            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(expected[i].SetEquals(actual[i]));
            }
        }
        private class Cases143 : IEnumerable
        {
            private const int Count = 3;
            public IEnumerator GetEnumerator()
            {
                var series = Enumerable.Range(0, Count).ToArray();
                for (int i = -1; i <= Count; i++)
                {
                    yield return new object[]{
                        i
                        ,series
                        ,new[] { series.Where(n => n < i).ToArray()
                            ,series.Where(n => n== i).ToArray()
                            ,series.Where(n => n > i).ToArray()
                        }
                    };
                }
            }
        }
    }
}
