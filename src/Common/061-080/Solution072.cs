using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution072
    {
        public static int? DoTheThing(GraphNode<int>[] graphNodes)
        {
            int? ret = null;

            if (!graphNodes[0]?.ContainsNegativeLoop() ?? false)
            {
                var paths = EveryPath(graphNodes);
                var mostUsedPathChar = paths.Select(p => p.GroupBy(c => c.Name).OrderByDescending(g => g.Count()).First());
                var mostUsedChar = mostUsedPathChar.OrderByDescending(g => g.Count()).First().Count();
                ret = mostUsedChar;
            }
            return ret;
        }
        private static GraphNode<int>[][] EveryPath(IEnumerable<GraphNode<int>> ListOfNodes)
        {
            var ret = new List<GraphNode<int>[]>();
            foreach (var node in ListOfNodes)
            {
                IEnumerable<GraphNode<int>[]> x = ListEveryPathFromHere(node);
                ret.AddRange(x);
            }
            return ret.ToArray();
        }
        private static IEnumerable<GraphNode<int>[]> ListEveryPathFromHere(GraphNode<int> node)
        {
            var ret = new List<GraphNode<int>>() { node };
            yield return ret.ToArray();
            foreach (var child in node.Children())
            {
                foreach (var grandChild in ListEveryPathFromHere(child))
                {
                    ret = new List<GraphNode<int>>() { node };
                    ret.AddRange(grandChild);
                    yield return ret.ToArray();
                }
            }
        }
        public static List<GraphNode<int>> GenerateConnectedNodes(string Text, (int from, int to)[] Links)
        {
            var nodeList = new List<GraphNode<int>>();
            nodeList.AddRange(GenerateNodes(Text));
            ConnectNodes(nodeList, Links);
            return nodeList;
        }
        private static void ConnectNodes(List<GraphNode<int>> nodeList, (int from, int to)[] Links)
        {
            foreach (var item in Links)
            {
                nodeList[item.from].ConnectTo(nodeList[item.to], -1);
            }
        }
        private static List<GraphNode<int>> GenerateNodes(string text)
        {
            var nodeList = new List<GraphNode<int>>();
            for (int i = 0; i < text.Length; i++)
            {
                nodeList.Add(new GraphNode<int>(i, text[i].ToString()));
            }

            return nodeList;
        }
    }
}