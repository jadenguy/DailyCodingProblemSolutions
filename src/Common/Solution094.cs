using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution094
    {
        public static BinaryTreePath MaxPath(BinaryNode<int> node, bool checkNegative = true)
        {
            if (node is null)
            { throw new System.Exception("null node checked"); }
            else
            {
                if (checkNegative && node.BreadthFirstSearch().OrderByDescending(n => n.Data).First().Data <= 0)
                {
                    return new BinaryTreePath(new BinaryNode<int>[] { node.BreadthFirstSearch().OrderByDescending(n => n.Data).First() }, false);
                }
                else
                {
                    BinaryTreePath root = new BinaryTreePath(new BinaryNode<int>[] { node }, true);
                    var proposals = new List<BinaryTreePath>() { root };
                    if (TryFindPath(node.Left, out var left)) { proposals.Add(left); }
                    if (TryFindPath(node.Right, out var right)) { proposals.Add(right); }
                    if (proposals.Count == 3) { proposals.Add(new BinaryTreePath(left, node, right)); }
                    var ret = proposals.OrderByDescending(p => p.Sum()).ThenBy(p => p.IsBranch ? 1 : 0).FirstOrDefault();
                    return ret;
                }
            }
        }
        private static bool TryFindPath(BinaryNode<int> node, out BinaryTreePath path)
        {
            path = null;
            bool isBranch = node != null;
            if (isBranch)
            {
                path = MaxPath(node, false);
                isBranch = path.Sum() > 0 && path.IsBranch;
            }
            return isBranch;
        }
    }
}