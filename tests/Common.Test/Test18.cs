// Given an array of integers and a number k, where 1 <= k <= length of the array, compute the maximum values of each subarray of length k.
// For example, given array = [10, 5, 2, 7, 8, 7] and k = 3, we should get: [10, 7, 8, 8], since:
// •	10 = max(10, 5, 2)
// •	7 = max(5, 2, 7)
// •	8 = max(2, 7, 8)
// •	8 = max(7, 8, 7)
// Do this in O(n) time and O(k) space. You can modify the input array in-place and you do not need to store the results. You can simply print them out as you compute them.


using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test18
    {
        [SetUp]
        public void SetUp() { }
        [Test]
        [TestCase(new int[] { 10, 5, 2, 7, 8, 7 }, 3, new int[] { 10, 7, 8, 8 })]
        public void Problem18(int[] input, int k, int[] output)
        {
            //-- Arrange
            var expected = output;

            //-- Act
            var actual = Solution18.PrintMaxValues(input, k);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

