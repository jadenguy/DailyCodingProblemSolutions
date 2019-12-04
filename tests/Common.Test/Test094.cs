// Given a binary tree of integers, find the maximum path sum between two nodes. The path must go through at least one node, and does not need to go through the root.

using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test094
    {
        List<BinaryNode<int>> nodes;
        List<int> results;
        private static BinaryNode<int> n(int data) => new BinaryNode<int>(data);
        [SetUp]
        public void Setup()
        {
            nodes = new List<BinaryNode<int>>();
            results = new List<int>();
            BinaryNode<int> root;
            var rand = new Random();

            // 0
            nodes.Add(root = n(0));
            root.Left = n(0);
            root.Right = n(0);
            root.Left.Left = n(0);
            root.Left.Right = n(0);
            root.Right.Left = n(0);
            root.Right.Right = n(0);
            results.Add(0);

            // 1
            nodes.Add(root = n(-1));
            root.Left = n(0);
            root.Right = n(0);
            root.Left.Left = n(1);
            root.Left.Right = n(0);
            root.Right.Left = n(0);
            root.Right.Right = n(0);
            results.Add(1);

            // 2
            nodes.Add(root = n(-1000));
            root.Left = n(1);
            root.Right = n(2);
            results.Add(2);

            // 3
            nodes.Add(root = n(1));
            root.Left = n(1);
            root.Right = n(2);
            results.Add(4);

        }
        // [TearDown] public void TearDown() { }
        [Test]
        // [TestCase(0)]
        // [TestCase(1)]
        // [TestCase(2)]
        [TestCase(3)]
        public void Problem094(int testCase = 0)
        {
            //-- Arrange
            var expected = results[testCase];
            var node = nodes[testCase];

            //-- Act
            var binaryTreePath = Solution094.MaxPath(node);
            var actual = binaryTreePath.Sum();

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}