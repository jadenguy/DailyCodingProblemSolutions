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
        const int size = 10;
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem137()
        {
            //-- Arrange
            var bitArray = new Solution137.BitArray(size);
            var expectedArray = new[] { true, true, false, false, false, false, false, false, false, false };

            //-- Act
            bitArray.Set(0, true);
            var actualValue = bitArray.Get(0);
            bitArray[1] = true;
            bitArray[2] = true;
            bitArray[2] = false;
            bitArray[3] = false;
            var actualValueTwo = bitArray[1];
            var actualValueThree = bitArray[2];
            var actualCount = bitArray.StorageSize;
            var actualArray = bitArray.GetValues().ToArray();
            (bool largeIndexTest, bool negativeIndexTest) = (false, false);
            try { bitArray[size] = true; }
            catch (IndexOutOfRangeException oor) { largeIndexTest = (oor.Message) == Solution137.BitArray.BitArrayExceptionMessage; }
            try { bitArray[-1] = true; }
            catch (IndexOutOfRangeException oor) { negativeIndexTest = (oor.Message) == Solution137.BitArray.BitArrayExceptionMessage; }

            //-- Assert
            Assert.IsTrue(actualValue, "Failed to set first value");
            Assert.IsTrue(actualValueTwo, "Failed to set second Value");
            Assert.IsTrue(!actualValueThree, "Failed to set third value");
            Assert.IsTrue(negativeIndexTest, "Negative Index Accepted");
            Assert.IsTrue(largeIndexTest, "Positive Index Accepted");
            Assert.IsTrue(expectedArray.SequenceEqual(actualArray), "Array values incorrect");
        }
    }
}