// You are given an array of non-negative integers that represents a two-dimensional elevation map where each element is unit-width wall and the integer is the height. Suppose it will rain and all spots between two walls get filled up.
// Compute how many units of water remain trapped on the map in O(N) time and O(1) space.
// For example, given the input [2, 1, 2], we can hold 1 unit of water in the middle.
// Given the input [3, 0, 1, 3, 0, 5], we can hold 3 units in the first index, 2 in the second, and 3 in the fourth index (we cannot hold 5 since it would run off to the left), so we can trap 8 units of water.

using NUnit.Framework;

namespace Common.Test
{
    public class Test30
    {

        [SetUp]
        public void Setup() { }
        [Test]
        [TestCase(new int[] { 3, 1, 2 }, 1)]
        [TestCase(new int[] { 3, 1, 1, 2 }, 2)]
        [TestCase(new int[] { 2, 1, 2 }, 1)]
        [TestCase(new int[] { 3, 0, 1, 3, 0, 5 }, 8)]
        public void Problem30(int[] array, int water)
        {
            //-- Arrange
            var expected = water;

            //-- Act
            int actual = Solution30.FillWithWater(array);

            //-- Assert        
            Assert.AreEqual(actual, expected);

        }
    }
}