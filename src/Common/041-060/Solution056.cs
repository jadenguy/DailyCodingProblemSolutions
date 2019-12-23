using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution056
    {
        public static bool IsColorable(GraphNode<string> node, int k)
        {
            var ret = true;
            if (k < 4)
            {
                ret = node.BreadthFirstSearch()
                    .Select(centerNode => centerNode.Children()
                        .Select(neighbor => neighbor.Children()
                            .Where(sharedNeighbor => centerNode.Children()
                                .Contains(sharedNeighbor))
                               .Count()) // these are how many cells are co-neighbor with a specific node
                       .Max()) // from a center node, this is the largest co-neighbor group
                    .Max() < k; // for all cells, this is the most co-neighbor group of all groups
            }
            return ret;
        }
    }
}