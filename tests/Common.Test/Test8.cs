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
using Common;
using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test8
    {
        public List<BinaryNode> root = new List<BinaryNode>();

        public List<int> univalCount = new List<int>();
        [SetUp]
        public void Setup()
        {
            root.Add(new BinaryNode("0"));
            univalCount.Add(1);
            root.Add(new BinaryNode("0"));
            root[1].Left = new BinaryNode("1");
            root[1].Right = new BinaryNode("0");
            root[1].Right.Right = new BinaryNode("0");
            root[1].Right.Left = new BinaryNode("1");
            root[1].Right.Left.Left = new BinaryNode("1");
            root[1].Right.Left.Right = new BinaryNode("1");
            univalCount.Add(5);
        }
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void Problem8(int index)
        {
            //-- Arrange
            var expected = univalCount[index];
            var binaryNode = root[index];

            //-- Act
            var actual = Solution8.CountUnival(binaryNode, out var SubUnivalCount);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}