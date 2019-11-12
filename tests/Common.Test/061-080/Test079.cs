// Given an array of integers, write a function to determine whether the array could become non-decreasing by modifying at most 1 element.
// For example, given the array [10, 5, 7], you should return true, since we can modify the 10 into a 1 to make the array non-decreasing.
// Given the array [10, 5, 1], you should return false, since we can't modify any one element to get a non-decreasing array.

using NUnit.Framework;

namespace Common.Test
{
    public class Test079
    {
        // [SetUp]
        // public void Setup() { }
        // [TearDown] public void TearDown() { }

        [Test]
        [TestCase(new int[] { 10, 5, 7 }, true)]
        [TestCase(new int[] { 10, 5, 1 }, false)]
        [TestCase(new int[] { 1, 1, 3 }, true)]
        [TestCase(new int[] { 1, 0, 3 }, true)]
        [TestCase(new int[] { -100, -99, -97, -98 }, true)]
        public void Problem079(int[] array, bool result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            bool actual = Solution079.ReplaceOneForNonDescending(array);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}