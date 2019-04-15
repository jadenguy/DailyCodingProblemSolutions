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
    public class Test3
    {
        public Node root;
        public string serializedNode;
        [SetUp]
        public void Setup()
        {
            root = new Node("root");
            root.Left = new Node("left");
            root.Right = new Node("right");
            root.Left.Left = new Node("left.left");
            serializedNode = "{\"Value\":\"root\",\"Left\":{\"Value\":\"left\",\"Left\":{\"Value\":\"left.left\",\"Left\":null,\"Right\":null},\"Right\":null},\"Right\":{\"Value\":\"right\",\"Left\":null,\"Right\":null}}";
        }
        [TearDown]
        public void TearDown() { }
        [Test]
        public void Problem3Serialization()
        {
            //-- Arrange
            var expected = serializedNode;

            //-- Act
            string actual = Solution3.SerializeNodes(root);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem3Deserialization()
        {
            //-- Arrange
            var expected = "left.left";
            string serialized = Solution3.SerializeNodes(root);

            //-- Act
            var actual = Solution3.DeserializeNodes(serialized).Left.Left.Value;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}