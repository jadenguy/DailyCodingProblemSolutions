// Given a sorted list of integers, square the elements and give the output in sorted order.
// For example, given [-9, -2, 0, 2, 3], return [0, 4, 4, 9, 81].


using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test118
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(new int[] { -9, -2, 0, 2, 3 }, new int[] { 0, 4, 4, 9, 81 })]
        public void Problem118(int[] input, int[] result)
        {
            //-- Arrange
            var expected = result;
            input.Print(",").WriteHost("Source");
            expected.Print(",").WriteHost("Expected");

            //-- Act
            int[] actual = Solution118.OrderedSquares(input);
            actual.Print(",").WriteHost("Actual");

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
