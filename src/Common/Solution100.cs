using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Node;

namespace Common
{
    public static class Solution100
    {
        public static int FewestSteps((int, int)[] tiles)
        {
            //short loops are always simple, skip these
            int? length = tiles?.Length;
            if ((length ?? 0) <= 2) { return length - 1 ?? 0; }
            var graph = MakeGraph(tiles);
            // shortcut here that we can assume that if the
            // rest of the graph is fully interconnected,
            // you can just traverse from every node to 
            // every other node in one step, and we only
            // care about the second point forward, since
            // we have to move in one direction out from
            // the first .point
            if (IsAlreadyInterconnected(graph)) { return length - 1 ?? 0; }
            graph.InterconnectEveryPointWithMaxPathLength();
            return ShortestPathLength(graph);
        }

        private static bool IsAlreadyInterconnected(GraphNode graph)
        {
            var graphList = graph.BreadthFirstSearch().Skip(1).ToArray();
            var pathCount = graphList.Select(n => n.Paths.Keys.Where(k => k != graph).Count());
            var min = pathCount.Min();
            var max = pathCount.Max();
            bool maxPath = min == graphList.Length - 1;
            bool minPath = max == graphList.Length - 1;
            return minPath && maxPath;
        }

        private static int ShortestPathLength(GraphNode graph)
        {
            var list = graph.BreadthFirstSearch().ToArray();
            var permutationsOfSuffix = list.Skip(1).EveryPermutation().Select(r => list.Take(1).Union(r).ToArray()).ToArray();
            return permutationsOfSuffix.Min(p => PathLength(p));
        }
        private static int PathLength(GraphNode[] suggestion)
        {
            int result = int.MaxValue;
            for (int i = 1; i < suggestion.Length; i++)
            {
                var pathLength = 0d;
                var l = suggestion[i - 1];
                var r = suggestion[i];
                pathLength += l.Paths[r];
                result = Math.Min(result, (int)pathLength);
            }
            return result;
        }
        private static GraphNode InterconnectEveryPointWithMaxPathLength(this GraphNode graph)
        {
            var distanceGraphs = graph.BreadthFirstSearch().ToDictionary(k => k, v => graph.BreadthFirstSearch().ToDictionary(k => k, v2 => double.PositiveInfinity));
            foreach (var subGraph in distanceGraphs)
            {
                var key = subGraph.Key;
                distanceGraphs[key][key] = 0;
                distanceGraphs[key].BellmanFord();
                foreach (var item2 in subGraph.Value)
                {
                    key.ConnectTo(item2.Key, item2.Value);
                }
            }
            return graph;
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