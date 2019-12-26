// Print the nodes in a binary tree level-wise. For example, the following should print 1, 2, 3, 4, 5.
//   1
//  / \
// 2   3
//    / \
//   4   5

using System;
using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test107
    {
        List<BinaryNode<int>> nodes;
        List<string> results;
        private static BinaryNode<int> n(int data) => new BinaryNode<int>(data);
        [SetUp]
        public void Setup()
        {
            nodes = new List<BinaryNode<int>>();
            results = new List<string>();
            BinaryNode<int> root;
            var rand = new Random();

            // 0
            nodes.Add(root = n(1));
            root.Left = n(2);
            root.Right = n(3);
            root.Right.Left = n(4);
            root.Right.Right = n(5);
            results.Add($"  1\n / \\\n2   3\n   / \\\n  4   5\n");

            // // 1
            // nodes.Add(root = n(-1));
            // root.Left = n(0);
            // root.Right = n(0);
            // root.Left.Left = n(1);
            // root.Left.Right = n(0);
            // root.Right.Left = n(0);
            // root.Right.Right = n(0);
            // results.Add(1);

            // // 2
            // nodes.Add(root = n(-1000));
            // root.Left = n(1);
            // root.Right = n(2);
            // results.Add(2);

            // // 3
            // nodes.Add(root = n(1));
            // root.Left = n(1);
            // root.Right = n(2);
            // results.Add(4);

            // // 4
            // nodes.Add(root = n(2));
            // root.Left = n(-1);
            // root.Left.Left = n(100);
            // results.Add(101);

            // // 5
            // nodes.Add(root = n(0));
            // root.Left = n(0);
            // root.Right = n(0);
            // root.Left.Left = n(0);
            // root.Left.Right = n(1);
            // root.Right.Left = n(1);
            // root.Right.Right = n(0);
            // results.Add(2);
        }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(0)]
        // [TestCase(1)]
        // [TestCase(2)]
        // [TestCase(3)]
        // [TestCase(4)]
        // [TestCase(5)]
        public void Problem107(int testCase = 0)
        {
            //-- Arrange
            var expected = results[testCase];
            System.Console.WriteLine("");
            System.Diagnostics.Debug.WriteLine("");
            System.Console.WriteLine(expected);
            System.Diagnostics.Debug.WriteLine(expected);
            var node = nodes[testCase];

            //-- Act
            var actual = Solution107.PrintTree(node);
            System.Console.WriteLine(actual);
            System.Diagnostics.Debug.WriteLine(actual);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
