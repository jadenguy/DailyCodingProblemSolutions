// A builder is looking to build a row of N houses that can be of K different colors. He has a goal of minimizing cost while ensuring that no two neighboring houses are of the same color.
// Given an N by K matrix where the nth row and kth column represents the cost to build the nth house with kth color, return the minimum cost which achieves this goal.

using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test019
    {
        [SetUp]
        public void SetUp() { }
        [Test]
        public void Problem019()
        {
            //-- Arrange
            var priceArray = new int[][]{new int[] {100,1,10}
                                        ,new int[] {1,10,100}
                                        ,new int[] {10,100,1}
                                        ,new int[] {100,1,10}
                                        ,new int[] {1,10,100}};
            var expected = new int[] { 1, 0, 2, 1, 0 };

            //-- Act
            var actual = Solution019.PickCheapestColorOptions(priceArray);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

