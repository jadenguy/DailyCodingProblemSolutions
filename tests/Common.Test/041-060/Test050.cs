// Suppose an arithmetic expression is given as a binary tree. Each leaf is an integer and each internal node is one of '+', '−', '∗', or '/'.
// Given the root to such a tree, write a function to evaluate it.
// For example, given the following tree:
//     *
//    / \
//   +    +
//  / \  / \
// 3  2  4  5
// You should return 45, as it is (3 + 2) * (4 + 5).


using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test050
    {
        List<BinaryNode<string>> nodes;
        List<int> evaluations;
        const string a = "+";
        const string s = "-";
        const string d = "/";
        const string m = "*";
        private BinaryNode<string> n(object v) => n(v.ToString());
        private static BinaryNode<string> n(string text, string name = null)
        {
            if (name is null) { name = text; }
            return new BinaryNode<string>(value: text, name: name);
        }
        [SetUp]
        public void Setup()
        {
            nodes = new List<BinaryNode<string>>();
            evaluations = new List<int>();
            BinaryNode<string> root;

            // 0 zero
            nodes.Add(root = n(0));
            evaluations.Add(0);

            // 1 add
            nodes.Add(root = n(a));
            root.Left = n(1);
            root.Right = n(2);
            evaluations.Add(3);

            // 2 subtract
            nodes.Add(root = n(s));
            root.Left = n(3);
            root.Right = n(1);
            evaluations.Add(2);

            // 3 multiply
            nodes.Add(root = n(m));
            root.Left = n(2);
            root.Right = n(3);
            evaluations.Add(6);

            // 4 divide
            nodes.Add(root = n(d));
            root.Left = n(6);
            root.Right = n(2);
            evaluations.Add(3);

            // 5 (3 + 2) * (4 + 5)
            var x = (3 + 2) * (4 + 5);
            nodes.Add(root = n(m));
            root.Left = n(a);
            root.Right = n(a);
            root.Left.Left = n(3);
            root.Left.Right = n(2);
            root.Right.Left = n(4);
            root.Right.Right = n(5);
            evaluations.Add(x);
        }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void Problem050(int testCase)
        {
            //-- Arrange
            var expected = evaluations[testCase];
            var node = nodes[testCase];

            //-- Act
            var actual = Solution050.Evaluate(node);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}