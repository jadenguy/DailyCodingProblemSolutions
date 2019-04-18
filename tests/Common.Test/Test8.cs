// Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.
// For example, given the following Node class
// class Node:
//     def __init__(self, val, left=None, right=None):
//         self.val = val
//         self.left = left
//         self.right = right
// The following test should pass:
// node = Node('root', Node('left', Node('left.left')), Node('right'))
// assert deserialize(serialize(node)).left.left.val == 'left.left'


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
            root.Add( new BinaryNode("0"));
            univalCount.Add(1);
            root.Add( new BinaryNode("0"));
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

            //-- Act
            var actual = Solution8.CountUnival(root[index]);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}