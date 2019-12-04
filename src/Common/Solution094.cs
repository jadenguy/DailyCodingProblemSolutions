using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution094
    {
        public static IEnumerable<BinaryTreePath> PathValues(BinaryNode<int> node, bool checkNegative = true)
        {
            if (node is null)
            { throw new System.Exception("null node checked"); }
            else
            {
                if (checkNegative && node.BreadthFirstSearch().OrderByDescending(n => n.Data).First().Data <= 0)
                {
                    BinaryNode<int>[] nodes = new BinaryNode<int>[] { node.BreadthFirstSearch().OrderByDescending(n => n.Data).First() };
                    return new BinaryTreePath[] { new BinaryTreePath(nodes, false) };
                }
                else
                {
                    BinaryTreePath root = new BinaryTreePath(new BinaryNode<int>[] { node }, true);
                    var ret = new List<BinaryTreePath>() { root };
                    foreach (var branch in node.Children())
                    {
                        var branchPaths = PathValues(branch);
                        ret.AddRange(branchPaths.Select(p => new BinaryTreePath(p.Nodes, false)));
                    }
                    return ret;
                }
            }
        }
    }
}