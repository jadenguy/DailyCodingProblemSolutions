// Given the root of a binary tree, return a deepest node. For example, in the following tree, return d.
//     a
//    / \
//   b   c
//  /
// d


using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test080
    {
        List<BinaryNode<string>> nodes;
        List<BinaryNode<string>> evaluations;

        private static BinaryNode<string> n(string text, string name = null)
        {
            if (name is null) { name = text; }
            return new BinaryNode<string>(data: text, name: name);
        }
        private BinaryNode<string> n(object v) => n(v.ToString());
        [SetUp]
        public void Setup()
        {
            nodes = new List<BinaryNode<string>>();
            evaluations = new List<BinaryNode<string>>();
            BinaryNode<string> root;

            // 0
            nodes.Add(root = n('a'));
            root.Left = n('b');
            root.Right = n('c');
            root.Left.Left = n('d');
            evaluations.Add(root.Left.Left);


            // 1
            nodes.Add(root = n(0));
            root.Left = n(1);
            root.Right = n(2);
            evaluations.Add(root.Left);

            // 2
            nodes.Add(root = n(0));
            root.Left = n(3);
            root.Right = n(1);
            root.Right.Right = n(1);
            root.Right.Right.Right = n(1);
            evaluations.Add(root.Right.Right.Right);
        }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        // [TestCase(3)]
        // [TestCase(4)]
        // [TestCase(5)]
        public void Problem080(int testCase)
        {
            //-- Arrange
            var expected = evaluations[testCase];
            var node = nodes[testCase];

            //-- Act
            var actual = Solution080.Evaluate(node);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}