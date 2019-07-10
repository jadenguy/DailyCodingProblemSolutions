using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node.Graph;
using NUnit.Framework;

namespace Common.Test.Node
{
    public static class BellmanFordTest
    {
        [Test]
        public static void Test()
        {
            //-- Arrange
            // var expected = true;
            var graphArray = new GraphNode[] {
                // new GraphNode("NZD"),
                // new GraphNode("SEK"),
                // new GraphNode("CNY"),
                // new GraphNode("CHF"),
                // new GraphNode("CAD"),
                // new GraphNode("AUD"),
                // new GraphNode("GBP"),
                // new GraphNode("JPY"),
                new GraphNode("EUR"),
                new GraphNode("USD"),
            };
            var rand = new Random();
            foreach (var node in graphArray)
            {
                foreach (var otherNode in graphArray.Where(x => x != node).Where(y => !y.Paths.ContainsKey(node)))
                {
                    double weight = rand.NextDouble();
                    node.ConnectTo(otherNode, weight);
                    otherNode.ConnectTo(node, 1 / weight);
                }
            }
            var BellmanFordChart = graphArray.ToDictionary(k => k, v => double.PositiveInfinity);
            BellmanFordChart[BellmanFordChart.Keys.First()] = 0;

            //-- Act
            BellmanFordChart.BellmanFord();
            var firstRun = BellmanFordChart.BellmanFord().ToDictionary(k => k.Key, v => v.Value);
            var isConnected = firstRun.Select(k => k.Value).Where(v => !double.IsFinite(v)).Any();


            var someNode = graphArray[1];
            someNode.ConnectTo(someNode, -.1);

            BellmanFordChart.BellmanFord(0,false,true);
            BellmanFordChart.BellmanFord(0,false,true);
            var secondRun = BellmanFordChart.BellmanFord(0, true, true).ToDictionary(k => k.Key, v => v.Value);
            var actualTrue = secondRun.Select(k => k.Value).Where(v => !double.IsFinite(v)).Any();

            //-- Assert
            Assert.IsFalse(isConnected);
            Assert.IsTrue(actualTrue);
        }
    }
}