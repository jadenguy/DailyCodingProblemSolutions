// Given a list of integers and a number K, return which contiguous elements of the list sum to K.
// For example, if the list is [1, 2, 3, 4, 5] and K is 9, then it should return [2, 3, 4], since 2 + 3 + 4 = 9.

using NUnit.Framework;

namespace Common.Test
{
    public class Test102
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(nameof(Cases))]
        public void Problem102(int[] list, int k, int[] results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            var actual = Solution102.ContiguousListSum(list, k);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        static object[] Cases = { new object[] { new int[] { 1, 2, 3, 4, 5 }, 10, new int[] { 1, 2, 3, 4 } }
        , new object[] { new int[] { 1, 2, 3, 4, 5 }, 12, new int[] { 3, 4, 5 } }
        };
    }
}
