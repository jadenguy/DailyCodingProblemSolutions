// Given a list of integers, return the largest product that can be made by multiplying any three integers.
// For example, if the list is [-10, -10, 5, 2], we should return 500, since that's -10 * -10 * 5.
// You can assume the list has at least three integers.

using NUnit.Framework;

namespace Common.Test
{
    public class Test069
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown(){}
        [Test]
        [TestCase(new int[] { -10, -10, 5, 2 }, 500)]
        [TestCase(new int[] { -10, 0, 5, 2 }, 0)]
        public void Problem069(int[] array, int result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            var actual = Solution069.LargestProductOfThree(array);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}