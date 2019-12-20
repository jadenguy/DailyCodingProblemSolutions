using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Node;

namespace Common
{
    public class Solution100
    {
        public static int FewestSteps((int, int)[] tiles)
        {
            if (tiles == null || tiles.Length == 0) { return 0; }
            var graph = MakeGraph(tiles);
            var distances = DistanceFromZero(graph);
            var ret = PathLength(distances);
            return ret;
            throw new NotImplementedException();
        }
        private static int PathLength(object distances)
        {
            throw new NotImplementedException();
        }
        private static Dictionary<GraphNode, double> DistanceFromZero(GraphNode graph)
        {
            var bellmanFordChart = graph.BreadthFirstSearch().ToDictionary(k => k, v => double.PositiveInfinity);
            bellmanFordChart[graph] = 0;
            bellmanFordChart.BellmanFord();
            return bellmanFordChart;
        }
        private static GraphNode MakeGraph((int x, int y)[] tiles)
        {
            if (tiles.IsNullOrEmpty()) { return null; }
            var nodes = new List<GraphNode>();
            for (int i = 0; i < tiles.Length; i++)
            {
                var a = tiles[i];
                nodes.Add(new GraphNode($"([( {a.x} , {a.y} )])"));
                for (int j = 0; j < i; j++)
                {
                    var b = tiles[j];
                    if (Math.Abs(a.x - b.x) <= 1 && Math.Abs(a.y - b.y) <= 1)
                    {
                        nodes[i].ConnectTo(nodes[j]);
                        nodes[j].ConnectTo(nodes[i]);
                    }
                }
            }
            return nodes.FirstOrDefault();
        }
    }
}