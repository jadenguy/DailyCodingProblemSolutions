// You have a large array with most of the elements as zero.
// Use a more space-efficient data structure, SparseArray, that implements the same interface:
// •	init(arr, size): initialize with the original large array and size.
// •	set(i, val): updates index at i with val.
// •	get(i): gets the value at index i.


using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Test
{
    public class Test134
    {
        private const int Count = 5;

        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem134()
        {
            //-- Arrange
            //an array that begins with a pair of 0, has the digits 2 through 6 sprinkled around a then ten thousand empty spots
            int[] first = (new[] { 0, 0 });
            var second = Enumerable.Range(2, Count).Concat(Enumerable.Repeat(0, 10000)).Shuffle(134).ToArray();
            var array = first.Concat(second).ToArray();
            var size = array.Count();
            var a = new Solution134.SparseArray<int>(array);
            var expectedValue = 1;
            var expectedNoValue = 0;
            var expectedCount = Count + 1;

            //-- Act
            a.Set(0, 1);
            var actualValue = a.Get(0);
            var actualNoValue = a.Get(1);
            var actualCount = 6;

            //-- Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedNoValue, actualNoValue);
            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}