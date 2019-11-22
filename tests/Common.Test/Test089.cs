// Determine whether a tree is a valid binary search tree.
// A binary search tree is a tree with two children, left and right, and satisfies the constraint that the key in the left child must be less than or equal to the root and the key in the right child must be greater than or equal to the root.


using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test089
    {
        List<BinaryNode<int>> nodes;
        List<bool> isBST;

        private static BinaryNode<int> n(int text)
        {
            return new BinaryNode<int>(data: text);
        }
        private BinaryNode<string> n(object v) => n(v.ToString());
        [SetUp]
        public void Setup()
        {
            nodes = new List<BinaryNode<int>>();
            isBST = new List<bool>();
            BinaryNode<int> root;

            // 0
            nodes.Add(root = n('a'));
            root.Left = n('b');
            root.Right = n('c');
            root.Left.Left = n('d');
            root.Left.Right = n('e');
            root.Right.Left = n('f');
            isBST.Add(false);
            var x = new BinarySearchNode();
        }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(0)]
        public void Problem089(int testCase)
        {
            //-- Arrange
            var expected = isBST[testCase];
            var node = nodes[testCase];

            //-- Act
            var actual = Solution089.IsBST(node);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}