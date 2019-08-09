// Given pre-order and in-order traversals of a binary tree, write a function to reconstruct the tree.
// For example, given the following preorder traversal:
// [a, b, d, e, c, f, g]
// And the following inorder traversal:
// [d, b, e, a, f, c, g]
// You should return the following tree:
//     a
//    / \
//   b   c
//  / \ / \
// d  e f  g

using System.Collections.Generic;
using System.Linq;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test048
    {
        List<BinaryNode<string>> nodes;
        List<BinaryNode<string>[]> poNodes;
        List<BinaryNode<string>[]> ioNodes;
        const string a = "A";
        const string b = "B";
        const string c = "C";
        const string d = "D";
        const string e = "E";
        const string f = "F";
        const string g = "G";
        private static BinaryNode<string> n(string text, string name = null)
        {
            if (name is null)
            {
                name = text;
            }

            return new BinaryNode<string>(value: text, name: name);
        }

        [SetUp]
        public void Setup()
        {
            nodes = new List<BinaryNode<string>>();
            poNodes = new List<BinaryNode<string>[]>();
            ioNodes = new List<BinaryNode<string>[]>();
            BinaryNode<string> root;

            // linear
            nodes.Add(root = n(a,"root"));
            root.Left = n(b);
            root.Left.Left = n(c);
            AddResults(root);

            // 1 branch
            nodes.Add(root = n(a,"root"));
            root.Left = n(b);
            root.Right = n(c);
            AddResults(root);

            // 2 height branch
            nodes.Add(root = n(a,"root"));
            root.Left = n(b);
            root.Right = n(c);
            root.Left.Left = n(d);
            root.Left.Right = n(e);
            root.Right.Left = n(f);
            root.Right.Right = n(g);
            AddResults(root);
        }

        private void AddResults(BinaryNode<string> root)
        {
            poNodes.Add(root.PreOrder().Select(k => n(k.Data)).ToArray());
            ioNodes.Add(root.InOrder().Select(k => n(k.Data)).ToArray());
        }

        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void Problem048(int testCase)
        {
            //-- Arrange
            var expected = nodes[testCase];
            var preOrder = poNodes[testCase];
            var inOrder = ioNodes[testCase];

            //-- Act
            var actual = Solution048.Reconstruct(preOrder, inOrder);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}