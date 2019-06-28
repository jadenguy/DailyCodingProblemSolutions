using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class BreathFirstDepthFirst
    {
        public List<BinaryNode> root = new List<BinaryNode>();

        public List<int> nodeCount = new List<int>();
        [SetUp]
        public void Setup()
        {
            root.Add(new BinaryNode("0"));
            nodeCount.Add(1);
            root.Add(new BinaryNode("0"));
            root[1].Left = new BinaryNode("1");
            root[1].Right = new BinaryNode("0");
            root[1].Right.Right = new BinaryNode("0");
            root[1].Right.Left = new BinaryNode("1");
            root[1].Right.Left.Left = new BinaryNode("1");
            root[1].Right.Left.Right = new BinaryNode("1");
            root[1].Right.Right.Left = new BinaryNode("1");
            root[1].Right.Right.Right = new BinaryNode("1");
            nodeCount.Add(9);
        }
        [Test]
        // [TestCase(0)]
        [TestCase(1)]
        public void BreadthFirst(int index)
        {
            //-- Arrange
            var expected = nodeCount[index];
            var binaryNode = root[index];
            //-- Act
            var list = new List<BinaryNode>(binaryNode.BreadthFirstSearch());
            var actual = list.Count;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        // [TestCase(0)]
        [TestCase(1)]
        public void DepthFirst(int index)
        {
            //-- Arrange
            var expected = nodeCount[index];
            var binaryNode = root[index];
            //-- Act
            var list = new List<BinaryNode>(binaryNode.DepthFirstSearch());
            var actual = list.Count;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}