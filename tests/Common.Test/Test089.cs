// Determine whether a tree is a valid binary search tree.
// A binary search tree is a tree with two children, left and right, and satisfies the constraint that the key in the left child must be less than or equal to the root and the key in the right child must be greater than or equal to the root.


using System;
using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test089
    {
        List<BinaryNode<int>> nodes;
        List<bool> results;

        private static BinaryNode<int> n(int text)
        {
            return new BinaryNode<int>(data: text);
        }
        private BinaryNode<string> n(object v) => n(v.ToString());
        [SetUp]
        public void Setup()
        {
            nodes = new List<BinaryNode<int>>();
            results = new List<bool>();
            BinaryNode<int> root;
            var rand = new Random();

            // 0
            var x = new BinarySearchNode(rand.Next());
            x.Add(rand.Next());
            x.Add(rand.Next());
            x.Add(rand.Next());
            x.Add(rand.Next());
            x.Add(rand.Next());
            x.Add(rand.Next());
            x.Add(rand.Next());
            x.Add(rand.Next());
            x.Add(rand.Next());
            nodes.Add(x);
            results.Add(true);

            // 1
            nodes.Add(root = n(0));
            root.Left = n(0);
            root.Right = n(0);
            root.Left.Left = n(0);
            root.Left.Right = n(0);
            root.Right.Left = n(0);
            root.Right.Right = n(0);
            results.Add(false);
            nodes.Add(root = n(0));
            root.Left = n(1);
            root.Right = n(2);
            root.Left.Left = n(3);
            root.Left.Right = n(4);
            root.Right.Left = n(5);
            root.Right.Right = n(6);
            results.Add(false);

        }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Problem089(int testCase = 0)
        {
            //-- Arrange
            var expected = results[testCase];
            var node = nodes[testCase];

            //-- Act
            var actual = Solution089.IsBST(node);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}