// In a directed graph, each node is assigned an uppercase letter. We define a path's value as the number of most frequently-occurring letter along that path. For example, if a path in the graph goes through "ABACA", the value of the path is 3, since there are 3 occurrences of 'A' on the path.
// Given a graph with n nodes and m directed edges, return the largest value path of the graph. If the largest value is infinite, then return null.
// The graph is represented with a string and an edge list. The i-th character represents the uppercase letter of the i-th node. Each tuple in the edge list (i, j) means there is a directed edge from the i-th node to the j-th node. Self-edges are possible, as well as multi-edges.
// For example, the following input graph:
// ABACA
// [(0, 1),
//  (0, 2),
//  (2, 3),
//  (3, 4)]
// Would have maximum value 3 using the path of vertices [0, 2, 3, 4], (A, A, C, A).
// The following input graph:
// A
// [(0, 0)]
// Should return null, since we have an infinite loop.

using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test072
    {
        static List<GraphNode[]> nodes;
        static List<int?> results;
        [SetUp]
        public void Setup()
        {
            nodes = new List<GraphNode[]>();
            results = new List<int?>();
            AddTest(3, "ABACA", new (int from, int to)[] { (0, 1), (0, 2), (2, 3), (3, 4) });
            AddTest(null, "A", new (int from, int to)[] { (0, 0) });
            AddTest(4, "ABACADA", new (int from, int to)[] { (0, 1), (0, 2), (2, 3), (3, 4), (1, 5), (5, 6), (4, 6) });
        }

        private static void AddTest(int? result, string Text, (int from, int to)[] g)
        {
            List<GraphNode> nodeList = GenerateConnectedNodes(Text, g);
            results.Add(result);
            nodes.Add(nodeList.ToArray());
        }

        private static List<GraphNode> GenerateConnectedNodes(string Text, (int from, int to)[] Links)
        {
            var nodeList = new List<GraphNode>();
            nodeList.AddRange(GenerateNodes(Text));
            ConnectNodes(nodeList, Links);
            return nodeList;
        }

        private static void ConnectNodes(List<GraphNode> nodeList, (int from, int to)[] Links)
        {
            foreach (var item in Links)
            {
                nodeList[item.from].ConnectTo(nodeList[item.to], -1);
            }
        }
        private static List<GraphNode> GenerateNodes(string text)
        {
            var nodeList = new List<GraphNode>();
            foreach (var item in text)
            {
                nodeList.Add(new GraphNode(item.ToString()));
            }
            GraphNode x = new GraphNode("A");
            return nodeList;
        }

        // [TearDown] public void TearDown(){}
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Problem072(int testIndex)
        {
            //-- Arrange
            var expected = results[testIndex];
            var graphNode = nodes[testIndex];

            //-- Act
            var actual = Solution072.DoTheThing(graphNode);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}