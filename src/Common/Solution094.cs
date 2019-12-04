using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution094
    {
        private const BinaryTreePath.PathType ORPHAN = BinaryTreePath.PathType.Orphan;
        private const BinaryTreePath.PathType BRANCH = BinaryTreePath.PathType.Branch;
        private const BinaryTreePath.PathType FULL = BinaryTreePath.PathType.FullPath;
        public static BinaryTreePath MaxPathSum(BinaryNode<int> node, bool checkNegative = true)
        {
            if (node is null)
            { return null; }
            else
            {
                var largestNode = node.BreadthFirstSearch().OrderByDescending(n => n.Data).First();
                if (checkNegative || largestNode.Data <= 0) { return new BinaryTreePath(new BinaryNode<int>[] { largestNode }, ORPHAN); }
                else
                {
                    var left = MaxPathSum(node.Left, false);
                    var right = MaxPathSum(node.Right, false);
                    var proposals = new List<BinaryTreePath>() { left, right };
                    bool branchLeft = left.Sum() <= 0 || left.Type != BRANCH;
                    bool branchRight = right.Sum() <= 0 || right.Type != BRANCH;
                    if (branchLeft) { left = null; }
                    else { proposals.Add(new BinaryTreePath(left, node)); }
                    if (branchRight) { right = null; }
                    else { proposals.Add(new BinaryTreePath(right, node)); }
                    if (branchLeft && branchRight) { proposals.Add(new BinaryTreePath(left, node, right)); }
                    return proposals.OrderByDescending(p => p.Sum()).FirstOrDefault();
                }
            }
        }
    }
}