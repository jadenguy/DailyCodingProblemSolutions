// Given an array of numbers and an index i, return the index of the nearest larger number of the number at index i, where distance is measured in array indices.
// For example, given [4, 1, 3, 5, 6] and index 0, you should return 3.
// If two distances to larger numbers are the equal, then return any one of them. If the array at i doesn't have a nearest larger integer, then return null.

using System.Collections;
using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test144
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases144))]
        public static void Problem144(int[] array, int index, int[] result)
        {
            //-- Assert
            var expected = result;

            //-- Arrange
            var actual = Solution144.FindNearestLargeNumberIndexDelta(array, index);

            //-- Act
            Assert.IsTrue(expected.Any(v => v == actual));
        }
        private class Cases144 : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                var expected = new[] { 3 };
                var array = new[] { 4, 1, 3, 5, 6 };
                var index = 0;
                yield return new object[] { array, index, expected };
            }
        }
    }
}