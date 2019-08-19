// An sorted array of integers was rotated an unknown number of times.
// Given such an array, find the index of the element in the array in faster than linear time. If the element doesn't exist in the array, return null.
// For example, given the array [13, 18, 25, 2, 8, 10] and the element 8, return 4 (the index of 8 in the array).
// You can assume all the integers in the array are unique.

using NUnit.Framework;

namespace Common.Test
{
    public class Test058
    {
        // [SetUp] public void SetUp() { }
        [Test]
        [TestCase(new int[] { 13, 18, 25, 2, 8, 10 }, 8, 4)]
        [TestCase(new int[] { 13, 18, 25, 2, 8, 10 }, 9, null)]
        public void Problem058(int[] array, int value, int? index)
        {
            //-- Arrange
            var expected = index;

            //-- Act
            var actual = Solution058.FindRotatedSortedArrayIndex(array, value);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}