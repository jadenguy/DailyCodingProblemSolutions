// Given the root to a binary search tree, find the second largest node in the tree.


using Common.Node;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test036
    {
        // [SetUp]
        // public void Setup() { }
        // [TearDown]
        // public void TearDown() { }
        [Test]
        public void Problem036()
        {
            //-- Arrange
            var expected = new BinarySearchNode(14);
            var tree = new BinarySearchNode(7);
            tree.Add(new int[] { 10, 11, 8, 9, 14, 15, 12, 13, 2, 3, 0, 1, 6, 4, 5 });

            //-- Act
            BinarySearchNode actual = Solution36.SecondLargestNodeInTree(tree);

            //-- Assert
            Assert.AreEqual(expected.Data, actual.Data);
        }
    }
}