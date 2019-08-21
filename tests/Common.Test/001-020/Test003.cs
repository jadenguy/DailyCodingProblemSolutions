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


using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test003
    {
        public BinaryNode<string> root;
        public string serializedNode;
        [SetUp]
        public void Setup()
        {
            root = new BinaryNode<string>("root");
            root.Left = new BinaryNode<string>("left");
            root.Right = new BinaryNode<string>("right");
            root.Left.Left = new BinaryNode<string>("left.left");
            serializedNode = "{\"Data\":\"root\",\"Name\":\"Root\",\"Left\":{\"Data\":\"left\",\"Name\":\"Root.Left\",\"Left\":{\"Data\":\"left.left\",\"Name\":\"Root.Left.Left\",\"Left\":null,\"Right\":null},\"Right\":null},\"Right\":{\"Data\":\"right\",\"Name\":\"Root.Right\",\"Left\":null,\"Right\":null}}";
        }
        [TearDown]
        public void TearDown() { }
        [Test]
        public void Problem3Serialization()
        {
            //-- Arrange
            var expected = serializedNode;

            //-- Act
            string actual = Solution003.SerializeNodes(root);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem3Deserialization()
        {
            //-- Arrange
            var expected = "left.left";
            string serialized = Solution003.SerializeNodes(root);

            //-- Act
            var actual = Solution003.DeserializeNodes(serialized).Left.Left.Data;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}