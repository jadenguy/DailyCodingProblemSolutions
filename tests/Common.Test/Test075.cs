// Given an array of numbers, find the length of the longest increasing subsequence in the array. The subsequence does not necessarily have to be contiguous.
// For example, given the array [0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15], the longest increasing subsequence has length 6: it is 0, 2, 6, 9, 11, 15.


using NUnit.Framework;

namespace Common.Test
{
    public class Test075
    {

        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown(){}
        [Test]
        [TestCase(new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15, 3 }, 6)]
        [TestCase(new int[] { 10, 22, 9, 33, 21, 50, 41, 60, 80 }, 6)]
        [TestCase(new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15, 3, 1000 }, 7)]

        public void Problem075(int[] sequence, int result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            var actual = Solution075.LongestRaisingSequence(sequence);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}