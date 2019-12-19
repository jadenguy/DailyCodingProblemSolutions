using System;
using System.Collections.Generic;
using Common.Node;

namespace Common
{
    public class Solution100
    {
        public static int FewestSteps((int, int)[] tiles)
        {
            if (tiles == null || tiles.Length == 0) { return 0; }
            var graph = MakeGraph(tiles);
            var distances = DistanceFindFrom(graph);
            var ret = PathLength(distances);
            return ret;
            throw new NotImplementedException();
        }
        private static int PathLength(object distances)
        {
            throw new NotImplementedException();
        }
        private static object DistanceFindFrom(GraphNode graph)
        {
            throw new NotImplementedException();
        }
        private static GraphNode MakeGraph((int x, int y)[] tiles)
        {
            var nodes = new List<GraphNode>();
            for (int i = 0; i < tiles.Length; i++)
            {
                var a = new GraphNode($"{tiles[i].x}, {tiles[i].y}");
                nodes.Add(a);
                for (int j = 0; j < i; j++)
                {
                    var b = nodes[j];
                }
            }
            return nodes[0];
        }
    }
}