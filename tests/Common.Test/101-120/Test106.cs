// Given an integer list where each number represents the number of hops you can make, determine whether you can reach to the last index starting at index 0.
// For example, [2, 0, 1, 0] returns True while [1, 1, 0, 1] returns False.

using NUnit.Framework;

namespace Common.Test
{
    public class Test106
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(nameof(Cases))]
        public void Problem106(int[] input, bool results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            bool actual = Solution106.CanHop(input);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        static object[] Cases = {
            new object[] { new int[] {2, 0, 1, 0} ,true },
            new object[] { new int[] {1, 0, 1, 0} ,false },
            new object[] { new int[] {4, 0, 1, 0} ,true },
            new object[] { new int[] {3, 0, 0, 0} ,true }
        };
    }
}
