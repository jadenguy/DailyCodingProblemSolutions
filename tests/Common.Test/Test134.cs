// You have a large array with most of the elements as zero.
// Use a more space-efficient data structure, SparseArray, that implements the same interface:
// •	init(arr, size): initialize with the original large array and size.
// •	set(i, val): updates index at i with val.
// •	get(i): gets the value at index i.

using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Test
{
    public class Test134
    {
        private const int Count = 5;
        private const int V1 = 1;
        private const int V2 = Count + 2;

        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem134()
        {
            //-- Arrange
            //an array that begins with a pair of 0, has the digits 2 through 6 sprinkled around a then ten thousand empty spots
            int[] zeroValues = (new[] { 0, 0, 0 });
            var someValues = Enumerable.Range(2, Count).Concat(Enumerable.Repeat(0, 10000)).Shuffle(134).ToArray();
            var array = zeroValues.Concat(someValues).ToArray();
            var spareArray = new Solution134.SparseArray<int>(array);
            var expectedValue = V1;
            var expectedValueTwo = V2;
            var expectedNoValue = 0;
            var expectedCount = Count + 2;

            //-- Act
            spareArray.Set(0, V1);
            array[0] = V1;
            var actualValue = spareArray.Get(0);
            spareArray[1] = V2;
            array[1] = V2;
            var actualValueTwo = spareArray[1];
            var actualNoValue = spareArray[2];
            var actualCount = spareArray.StorageSize;
            var values = spareArray.GetValues().ToArray();
            (bool largeIndex, bool negativeIndex) = (false, false);
            try { spareArray[array.Length] = 1; }
            catch (IndexOutOfRangeException oor) { largeIndex = (oor.Message) == Solution134.SparseArray<int>.SparseArrayExceptionMessage; }
            try { spareArray[-1] = 1; }
            catch (IndexOutOfRangeException oor) { negativeIndex = (oor.Message) == Solution134.SparseArray<int>.SparseArrayExceptionMessage; }

            //-- Assert
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedValueTwo, actualValueTwo);
            Assert.AreEqual(expectedNoValue, actualNoValue);
            Assert.IsTrue(negativeIndex);
            Assert.IsTrue(largeIndex);
            Assert.AreEqual(expectedCount, actualCount);
            Assert.IsTrue(array.SequenceEqual(spareArray));
        }
    }
}