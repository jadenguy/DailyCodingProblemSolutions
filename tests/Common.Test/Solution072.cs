using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    internal class Solution072
    {
        internal static int? DoTheThing(GraphNode[] graphNodes)
        {
            int? ret = null;
            bool isLoop = DetectNegativeLoop(graphNodes);
            if (isLoop)
            {
                ret = 3;
                var paths = EveryPath(graphNodes);
                var mostUsedPathChar = paths.Select(p => p.GroupBy(c => c.Id)
                                                          .OrderByDescending(g => g.Count())
                                                          .First());
                var mostUsedChar = mostUsedPathChar.OrderByDescending(g => g.Count())
                                                   .First()
                                                   .Count();
                ret = mostUsedChar;
            }
            return ret;
        }
        private static bool DetectNegativeLoop(GraphNode[] graphNodes)
        {
            var bellmanFord = graphNodes.ToDictionary(g => g, g => 0d);
            Solution032.BellmanFord(bellmanFord);
            var isLoop = Solution032.BellmanFord(bellmanFord, 0, true, true).All(v => !double.IsNegativeInfinity(v.Value));
            return isLoop;
        }

        private static GraphNode[][] EveryPath(IEnumerable<GraphNode> ListOfNodes)
        {
            var ret = new List<GraphNode[]>();
            foreach (var node in ListOfNodes)
            {
                IEnumerable<GraphNode[]> x = ListEveryPathFromHere(node);
                ret.AddRange(x);
            }
            return ret.ToArray();
        }
        private static IEnumerable<GraphNode[]> ListEveryPathFromHere(GraphNode node)
        {
            var ret = new List<GraphNode>() { node };
            yield return ret.ToArray();
            foreach (var child in node.Children())
            {
                foreach (var grandChild in ListEveryPathFromHere(child))
                {
                    ret = new List<GraphNode>() { node };
                    ret.AddRange(grandChild);
                    yield return ret.ToArray();
                }
            }
        }
    }
}