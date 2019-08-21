// A unival tree (which stands for "universal value") is a tree where all nodes under it have the same value.
// Given the root to a binary tree, count the number of unival subtrees.
// For example, the following tree has 5 unival subtrees:
//    0
//   / \
//  1   0
//     / \
//    1   0
//   / \
//  1   1



using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test008
    {
        public List<BinaryNode<string>> root = new List<BinaryNode<string>>();

        public List<int> univalCount = new List<int>();
        [SetUp]
        public void Setup()
        {
            root.Add(new BinaryNode<string>("0"));
            univalCount.Add(1);
            root.Add(new BinaryNode<string>("0"));
            root[1].Left = new BinaryNode<string>("1");
            root[1].Right = new BinaryNode<string>("0");
            root[1].Right.Right = new BinaryNode<string>("0");
            root[1].Right.Left = new BinaryNode<string>("1");
            root[1].Right.Left.Left = new BinaryNode<string>("1");
            root[1].Right.Left.Right = new BinaryNode<string>("1");
            univalCount.Add(5);
        }
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void Problem008(int index)
        {
            //-- Arrange
            var expected = univalCount[index];
            var binaryNode = root[index];

            //-- Act
            var actual = Solution008.CountUnival(binaryNode, out var SubUnivalCount);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}