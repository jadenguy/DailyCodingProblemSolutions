// Given an array of numbers, find the maximum sum of any contiguous subarray of the array.
// For example, given the array [34, -50, 42, 14, -5, 86], the maximum sum would be 137, since we would take elements 42, 14, -5, and 86.
// Given the array [-5, -1, -8, -9], the maximum sum would be 0, since we would not take any elements.
// Do this in O(N) time.


using NUnit.Framework;

namespace Common.Test
{
    public class Test049
    {

        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(new int[] { 1, 1, 1, 1, 1 }, 5)]
        [TestCase(new int[] { 34, -50, 42, 14, -5, 86 }, 137)]
        [TestCase(new int[] { -5, -1, -8, -9 }, 0)]
        public void Problem049(int[] array, int maxSum)
        {
            //-- Arrange
            var expected = maxSum;

            //-- Act
            var actual = Solution049.FindLargestSubstring(array);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}