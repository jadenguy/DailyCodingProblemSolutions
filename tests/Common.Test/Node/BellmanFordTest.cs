using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Common.Node.Test
{
    public class BellmanFordTest
    {
        GraphNode<string>[] graphArray;
        Dictionary<GraphNode<string>, double> bellmanFordChart;
        [SetUp]
        public void SetUp()
        {
            graphArray = new GraphNode<string>[] {
                new GraphNode<string>("GOLD"),
                new GraphNode<string>("NZD"),
                new GraphNode<string>("SEK"),
                new GraphNode<string>("CNY"),
                new GraphNode<string>("CHF"),
                new GraphNode<string>("CAD"),
                new GraphNode<string>("AUD"),
                new GraphNode<string>("GBP"),
                new GraphNode<string>("JPY"),
                new GraphNode<string>("EUR"),
                new GraphNode<string>("USD"),
            };
            bellmanFordChart = graphArray.ToDictionary(k => k, v => double.PositiveInfinity);
            bellmanFordChart[graphArray[0]] = 0;

        }
        [Test]
        public void BellmanFordNegativeLinearLoop()
        {
            //-- Arrange
            this.LinearGraph();
            GraphNode<string> rootNode = graphArray[0];
            rootNode.ConnectTo(rootNode, .1); //create positive loop, ignored

            //-- Act
            var lacksLook = !rootNode.ContainsNegativeLoop();
            rootNode.ConnectTo(rootNode, -.1); //create negative loop, destroys chart
            var negativeLoop = rootNode.ContainsNegativeLoop();

            //-- Assert
            Assert.IsTrue(lacksLook, "A negative loop was detected");
            Assert.IsTrue(negativeLoop, "The negative loop was not detected");
        }
        [Test]
        public void BellmanFordNegativeLinearNoLoop()
        {
            //-- Arrange
            LinearGraph();

            //-- Act
            var noLoop = graphArray[0].BellmanFord(0, true, true).All(v => !double.IsNegativeInfinity(v.Value));

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
            var isConnected = graphArray[0].BellmanFord().All(v => !double.IsPositiveInfinity(v.Value));
            var noLoop = graphArray[0].BellmanFord(0, true, true).All(v => !double.IsNegativeInfinity(v.Value)); //no loop because every weight was positive

            //-- Assert
            Assert.IsTrue(isConnected, "Some node is not connected");
            Assert.IsTrue(noLoop, "A negative loop was detected");
        }
    }
}