// Invert a binary tree.
// For example, given the following tree:
//     a
//    / \
//   b   c
//  / \  /
// d   e f
// should become:
//   a
//  / \
//  c  b
//  \  / \
//   f e  d


using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test083
    {
        List<BinaryNode<string>> nodes;
        List<BinaryNode<string>> evaluations;

        private static BinaryNode<string> n(string text, string name = null)
        {
            if (name is null) { name = text; }
            return new BinaryNode<string>(value: text, name: name);
        }
        private BinaryNode<string> n(object v) => n(v.ToString());
        [SetUp]
        public void Setup()
        {
            nodes = new List<BinaryNode<string>>();
            evaluations = new List<BinaryNode<string>>();
            BinaryNode<string> root;
            BinaryNode<string> invertRoot;

            // 0
            nodes.Add(root = n('a'));
            root.Left = n('b');
            root.Right = n('c');
            root.Left.Left = n('d');
            evaluations.Add(invertRoot = n('a'));
            invertRoot.Right = n('b');
            invertRoot.Left = n('c');
            invertRoot.Right.Right = n('d');
        }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(0)]
        public void Problem083(int testCase)
        {
            //-- Arrange
            var expected = evaluations[testCase];
            var node = nodes[testCase];

            //-- Act
            var actual = Solution083.Invert(node);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}