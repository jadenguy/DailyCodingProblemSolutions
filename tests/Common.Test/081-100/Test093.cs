// Determine whether a tree is a valid binary search tree.
// A binary search tree is a tree with two children, left and right, and satisfies the constraint that the key in the left child must be less than or equal to the root and the key in the right child must be greater than or equal to the root.


using System;
using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test093
    {
        List<BinaryNode<int>> nodes;
        List<BinaryNode<int>> results;

        private static BinaryNode<int> n(int data) => new BinaryNode<int>(data);
        private BinaryNode<string> n(object v) => n(v.ToString());
        [SetUp]
        public void Setup()
        {
            nodes = new List<BinaryNode<int>>();
            results = new List<BinaryNode<int>>();
            BinaryNode<int> root;
            var rand = new Random();

            // 0
            var x = new BinarySearchNode(rand.Next());
            for (int i = 0; i < 10; i++) { x.Add(rand.Next()); }
            nodes.Add(x);
            results.Add(x);

            // 1
            nodes.Add(root = n(0));
            root.Left = n(0);
            root.Right = n(0);
            root.Left.Left = n(0);
            root.Left.Right = n(0);
            root.Right.Left = n(0);
            root.Right.Right = n(0);
            results.Add(root.Left.Left);

            // 2
            nodes.Add(root = n(0));
            root.Left = n(1);
            root.Right = n(2);
            root.Left.Left = n(3);
            root.Left.Right = n(4);
            root.Right.Left = n(5);
            root.Right.Right = n(6);
            root.Right.Right.Left = n(-1);
            root.Right.Right.Right = n(7);
            results.Add(root.Right.Right);
        }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Problem093(int testCase = 0)
        {
            //-- Arrange
            var expected = results[testCase];
            var node = nodes[testCase];

            //-- Act
            var actual = Solution093.LargestBST(node);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}