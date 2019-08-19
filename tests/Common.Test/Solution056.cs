using System.Collections.Generic;
using System.Linq;
using Common.Node;
using Common.Extensions;

namespace Common
{
    public class Solution056
    {
        public static bool IsColorable(GraphNode node, int k)
        {
            var ret = true;
            if (k < 4)
            {
                var nodes = node.BreadthFirstSearch().ToArray();
                foreach (var centerNode in nodes)
                {
                    var nodeChildren = new HashSet<GraphNode>(centerNode.Children());
                    var paths = nodeChildren.SelectMany(n => n.Paths
                            .Select(p => p.Key))
                        .Where(c => nodeChildren.Contains(c))
                        .ToArray();
                    paths.Print(",");
                }
            }
            return ret;
        }
    }
}