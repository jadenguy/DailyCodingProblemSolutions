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
            int? length = tiles?.Length;
            int ret = length - 1 ?? 0;
            //short loops are always simple, skip these
            if (length > 1)
            {
                // shortcut here that we can assume that if the
                // rest of the graph is fully interconnected,
                // you can just traverse from every node to 
                // every other node in one step, and we only
                // care about the second point forward, since
                // we have to move in one direction out from
                // the first .point
                var graph = MakeGraph(tiles);
                //bool solvedByNature = IsAlreadyInterconnectedOrLinear(graph);
                //if (!solvedByNature)
                //{
                graph.InterconnectEveryPointWithMaxPathLength();
                var pathLengths = PathLengths(graph).OrderBy(v => v.Value);
                System.Diagnostics.Debug.WriteLine(pathLengths.Select(p => $"{p.Value}: " + p.Key.Print(" ")).Print());
                int minPath = pathLengths.Select(v => v.Value).Min();
                ret = minPath;
                //}
            }
            return ret;
        }
        private static bool IsAlreadyInterconnectedOrLinear(GraphNode<string> graph)
        {
            var graphList = graph.BreadthFirstSearch().Skip(1).ToArray();
            var pathCount = graphList.Select(n => n.Paths.Keys.Where(k => k != graph).Count());
            var min = pathCount.Min();
            var max = pathCount.Max();
            bool maxPathIsLength = min == graphList.Length - 1;
            bool minPathIsLength = max == graphList.Length - 1;
            bool linearPath = min == 2 && max == 2;
            bool interconnected = (minPathIsLength && maxPathIsLength);
            return interconnected || linearPath;
        }
        private static Dictionary<GraphNode<string>[], int> PathLengths(GraphNode<string> graph)
        {
            var list = graph.BreadthFirstSearch().ToArray();
            var permutationsOfSuffix = list.Skip(1).EveryPermutation();
            var permutations = permutationsOfSuffix.Select(r => list.Take(1).Union(r).ToArray()).ToArray();
            return permutations.ToDictionary(k => k, v => PathLength(v));
        }
        private static int PathLength(GraphNode<string>[] suggestion)
        {
            int result = int.MaxValue;
            var pathLength = 0d;
            for (int i = 1; i < suggestion.Length; i++)
            {
                var l = suggestion[i - 1];
                var r = suggestion[i];
                pathLength += l.Paths[r];
            }
            result = Math.Min(result, (int)pathLength);
            return result;
        }
        private static GraphNode<string> InterconnectEveryPointWithMaxPathLength(this GraphNode<string> graph)
        {
            var distanceTable = graph.BreadthFirstSearch().ToDictionary(k => k, v => v.BellmanFord());
            foreach (var subTable in distanceTable)
            {
                var key = subTable.Key;
                foreach (var item2 in subTable.Value)
                {
                    if (key != item2.Key)
                    {
                        key.ConnectTo(item2.Key, item2.Value);
                        item2.Key.ConnectTo(key, item2.Value);
                    }
                }
            }
            return graph;
        }
        private static GraphNode<string> MakeGraph((int x, int y)[] tiles)
        {
            if (tiles.IsNullOrEmpty()) { return null; }
            var nodes = new List<GraphNode<string>>();
            for (int i = 0; i < tiles.Length; i++)
            {
                var a = tiles[i];
                nodes.Add(new GraphNode<string>($"([( {a.x} , {a.y} )])"));
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