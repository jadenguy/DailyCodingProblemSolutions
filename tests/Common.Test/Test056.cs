// Given an undirected graph represented as an adjacency matrix and an integer k, write a function to determine whether each vertex in the graph can be colored such that no two adjacent vertices share the same color using at most k colors.

using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test056
    {
        List<GraphNode> nodes = new List<GraphNode>();
        [SetUp]
        public void SetUp()
        {
            nodes.Clear();
            for (int i = 0; i < 6; i++)
            {
                nodes.Add(new GraphNode(i.ToString()));
            }
            Join(0, 2);
            Join(0, 3);
            Join(0, 5);
            Join(2, 3);
            Join(2, 1);
            Join(1, 3);
            Join(4, 3);
            Join(4, 5);
            Join(1, 5);
        }
        private void Join(int a, int b)
        {
            nodes[a].ConnectTo(nodes[b], 0);
            nodes[b].ConnectTo(nodes[a], 0);
        }

        [Test]
        [TestCase(0, 4, false)]
        public void Problem056(int nodeIndex, int k, bool color)
        {
            //-- Arrange
            var node = nodes[nodeIndex];

            //-- Act

            //-- Assert

        }
    }
}