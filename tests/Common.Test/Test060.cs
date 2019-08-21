// Given a multiset of integers, return whether it can be partitioned into two subsets whose sums are the same.
// For example, given the multiset {15, 5, 20, 10, 35, 15, 10}, it would return true, since we can split it up into {15, 5, 10, 15, 10} and {20, 35}, which both add up to 55.
// Given the multiset {15, 5, 20, 10, 35}, it would return false, since we can't split it up into two subsets that add up to the same sum.


using NUnit.Framework;

namespace Common.Test
{
    public class Test060
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(new int[]{15, 5, 20, 10, 35, 15, 10},false)]
        public void Problem060(int[] array, bool splittable)
        {
            //-- Arrange
            var expected = splittable;

            //-- Act
            var actual = Solution060.SplitArray(array);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}