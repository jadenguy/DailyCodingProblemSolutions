// Implement a bit array.
// A bit array is a space efficient array that holds a value of 1 or 0 at each index.
// •	init(size): initialize the array with size
// •	set(i, val): updates index at i with val where val is either 1 or 0.
// •	get(i): gets the value at index i.


using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Test
{
    public class Test137
    {
        const int size = 128;
        const bool V1 = true;
        const bool V2 = false;
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem137()
        {
            //-- Arrange
            var bitArray = new Solution137.BitArray(size);
            var array = bitArray;
            var expectedValue = V1;

            //-- Act
            bitArray.Set(0, V1);
            array[0] = V1;
            var actualValue = bitArray.Get(0);
            bitArray[1] = V2;
            array[1] = V2;
            var actualValueTwo = bitArray[1];
            var actualNoValue = bitArray[2];
            var actualCount = bitArray.StorageSize;
            var values = bitArray.GetValues().ToArray();
            (bool largeIndex, bool negativeIndex) = (false, false);
            // try { bitArray[array.Length] = 1; }
            // catch (IndexOutOfRangeException oor) { largeIndex = (oor.Message) == Solution137.SparseArray<int>.SparseArrayExceptionMessage; }
            // try { bitArray[-1] = 1; }
            // catch (IndexOutOfRangeException oor) { negativeIndex = (oor.Message) == Solution137.SparseArray<int>.SparseArrayExceptionMessage; }

            //-- Assert
            Assert.AreEqual(expectedValue, actualValue);
            // Assert.AreEqual(expectedValueTwo, actualValueTwo);
            // Assert.AreEqual(expectedNoValue, actualNoValue);
            Assert.IsTrue(negativeIndex);
            Assert.IsTrue(largeIndex);
            // Assert.AreEqual(expectedCount, actualCount);
            // Assert.IsTrue(array.SequenceEqual(bitArray));
        }
    }
}