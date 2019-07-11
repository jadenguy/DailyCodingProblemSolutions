using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node.Graph;
using NUnit.Framework;

namespace Common.Node.Test
{
    public class BellmanFordTest
    {
        GraphNode[] graphArray;
        Dictionary<GraphNode, double> bellmanFordChart;
        [SetUp]
        public void SetUp()
        {
            graphArray = new GraphNode[] {
                new GraphNode("GOLD"),
                new GraphNode("NZD"),
                new GraphNode("SEK"),
                new GraphNode("CNY"),
                new GraphNode("CHF"),
                new GraphNode("CAD"),
                new GraphNode("AUD"),
                new GraphNode("GBP"),
                new GraphNode("JPY"),
                new GraphNode("EUR"),
                new GraphNode("USD"),
            };
            bellmanFordChart = graphArray.ToDictionary(k => k, v => double.PositiveInfinity);
            bellmanFordChart[graphArray[0]] = 0;

        }
        [Test]
        public void BellmanFordNegativeLinearLoop()
        {
            //-- Arrange
            LinearGraph();

            graphArray[0].ConnectTo(graphArray[0], .1); //create positive loop, ignored

            //-- Act
            bellmanFordChart.BellmanFord();
            var noLoop = bellmanFordChart.BellmanFord(0, true, true).All(v => !double.IsNegativeInfinity(v.Value));
            graphArray[2].ConnectTo(graphArray[2], -.1); //create negative loop, destroys loop
            var negativeLoop = bellmanFordChart.BellmanFord(0, true, false).Where(v => double.IsNegativeInfinity(v.Value)).Any();

            //-- Assert
            Assert.IsTrue(noLoop, "A negative loop was detected");
            Assert.IsTrue(negativeLoop, "The negative loop was not detected");
        }
        [Test]
        public void BellmanFordNegativeLinearNoLoop()
        {
            //-- Arrange
            LinearGraph();

            //-- Act
            bellmanFordChart.BellmanFord();
            var noLoop = bellmanFordChart.BellmanFord(0, true, true).All(v => !double.IsNegativeInfinity(v.Value));

            //-- Assert
            Assert.IsTrue(noLoop, "A negative loop was detected");
        }

        private void LinearGraph()
        {
            for (int i = 1; i < graphArray.Length; i++) { graphArray[i - 1].ConnectTo(graphArray[i], -i); }
        }

        [Test]
        public void BellmanFordGraphConnectedNoNegativeNoLoop()
        {
            //-- Arrange
            var rand = new Random();
            foreach (var node in graphArray)
            {
                foreach (var otherNode in graphArray.Where(o => o != node).Where(o => !o.Paths.ContainsKey(node)))
                {
                    double weight = rand.NextDouble();
                    node.ConnectTo(otherNode, weight);
                    if (weight != 0) { otherNode.ConnectTo(node, 1 / weight); }
                    else { otherNode.ConnectTo(node, 1 / weight); }
                }
            }

            //-- Act
            var isConnected = bellmanFordChart.BellmanFord().All(v => !double.IsPositiveInfinity(v.Value));
            var noLoop = bellmanFordChart.BellmanFord(0, true, true).All(v => !double.IsNegativeInfinity(v.Value)); //no loop because every weight was positive

            //-- Assert
            Assert.IsTrue(isConnected, "Some node is not connected");
            Assert.IsTrue(noLoop, "A negative loop was detected");
        }
    }
}