// Given an unsorted array of integers, find the length of the longest consecutive elements sequence.
// For example, given [100, 4, 200, 1, 3, 2], the longest consecutive element sequence is [1, 2, 3, 4]. Return its length: 4.
// Your algorithm should run in O(n) complexity.

using NUnit.Framework;

namespace Common.Test
{
    public class Test099
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(new int[] { 100, 4, 200, 1, 3, 2 }, new int[] { 1, 2, 3, 4 })]
        public void Problem099(int[] array, int[] result)
        {
            //-- Arrange0            
            var expected = result;

            //-- Act
            int[] actual = Solution099.LongestConsecutiveSubset(array);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
