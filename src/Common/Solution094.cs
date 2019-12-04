using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution094
    {
        public static int LongestPathSum(BinaryNode<int> node, bool checkNegative = true)
        {
            double ret = 0;
            if (node is null) { throw new System.Exception("null node checked"); }
            var graph = CreateGraph(node);
            foreach (var item in graph.Keys)
            {
                var table = graph.Values.ToDictionary(k => k, v => double.PositiveInfinity);
                table[graph[item]] = -item.Data;
                double max = -table.BellmanFord().Values.Min();
                ret = Math.Max(ret, max);
            }
            return (int)ret;
        }
        private static Dictionary<BinaryNode<int>, GraphNode> CreateGraph(BinaryNode<int> node)
        {
            var ret = node.BreadthFirstSearch().ToDictionary(k => k, v => new GraphNode(v.Name));
            foreach (var parent in ret.Keys)
            {
                var p = ret[parent];
                foreach (var child in parent.Children())
                {
                    var c = ret[child];
                    p.ConnectTo(c, -child.Data);
                    // c.ConnectTo(p, -parent.Data);
                }
            }
            return ret;
        }
    }
}