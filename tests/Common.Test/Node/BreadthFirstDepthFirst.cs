using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Node.Test
{
    public class BreathFirstDepthFirst
    {
        public BinaryNode<int> root;
        public int nodeCount;
        [SetUp]
        public void Setup()
        {
            var count = 0;
            root = ArbitraryTreeBinaryNode.GenerateArbitaryBinaryTreeNode(count: ref count);
            nodeCount = count;
        }
        [TearDown]
        public void TearDown() { }
        [Test]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        public void BreadthFirst()
        {
            //-- Arrange
            var expected = nodeCount;
            var binaryNode = root;

            //-- Act
            var list = new List<string>(binaryNode.BreadthFirstSearch().Select(n => n.Name));
            var actual = list.Count;
            System.Diagnostics.Debug.WriteLine("");
            System.Console.WriteLine("");

            System.Diagnostics.Debug.WriteLine(list.Print());
            System.Console.WriteLine(list.Print());

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        public void PreOrder()
        {
            //-- Arrange
            var expected = nodeCount;
            var binaryNode = root;

            //-- Act
            var list = new List<string>(binaryNode.PreOrder().Select(n => n.Name));
            var actual = list.Count;
            System.Diagnostics.Debug.WriteLine("");
            System.Console.WriteLine("");
            list.ForEach(e =>
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    System.Console.WriteLine(e);
                }
            );

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        public void PostOrder()
        {
            //-- Arrange
            var expected = nodeCount;
            var binaryNode = root;

            //-- Act
            var list = new List<string>(binaryNode.PostOrder().Select(n => n.Name));
            var actual = list.Count;
            System.Diagnostics.Debug.WriteLine("");
            System.Console.WriteLine("");
            list.ForEach(e =>
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    System.Console.WriteLine(e);
                }
            );

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        public void InOrder()
        {
            //-- Arrange
            var expected = nodeCount;
            var binaryNode = root;

            //-- Act
            var list = new List<string>(binaryNode.InOrder().Select(n => n.Name));
            var actual = list.Count;
            System.Diagnostics.Debug.WriteLine("");
            System.Console.WriteLine("");
            list.ForEach(e =>
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    System.Console.WriteLine(e);
                }
            );

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]
        public void OutOrder()
        {
            //-- Arrange
            var expected = nodeCount;
            var binaryNode = root;

            //-- Act
            var list = new List<string>(binaryNode.OutOrder().Select(n => n.Name));
            var actual = list.Count;
            System.Diagnostics.Debug.WriteLine("");
            System.Console.WriteLine("");
            list.ForEach(e =>
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    System.Console.WriteLine(e);
                }
            );

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}