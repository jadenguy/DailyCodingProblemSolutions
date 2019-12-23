// Given an undirected graph represented as an adjacency matrix and an integer k, write a function to determine whether each vertex in the graph can be colored such that no two adjacent vertices share the same color using at most k colors.

using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test056
    {
        List<GraphNode<string>> nodes = new List<GraphNode<string>>();
        [SetUp]
        public void SetUp()
        {
            nodes.Clear();
            for (int i = 0; i < 6; i++)
            {
                nodes.Add(new GraphNode<string>(i.ToString()));
            }
            Join(0, 2);
            Join(0, 3);
            Join(0, 5);
            Join(1, 2);
            Join(1, 3);
            Join(1, 5);
            Join(2, 3);
            Join(3, 4);
            Join(4, 5);
        }
        private void Join(int a, int b)
        {
            nodes[a].ConnectTo(nodes[b], 0);
            nodes[b].ConnectTo(nodes[a], 0);
        }

        [Test]
        [TestCase(0, false)]
        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(3, true)]
        [TestCase(4, true)]
        public void Problem056(int k, bool color)
        {
            //-- Arrange
            var node = nodes[0];
            var expected = color;

            //-- Act
            var actual = Solution056.IsColorable(node, k);

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}