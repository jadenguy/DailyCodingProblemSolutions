using System.Collections.Generic;
using System.Linq;
using Common.Node;
using Common.Extensions;

namespace Common
{
    public class Solution094
    {
        public static BinaryTreePath[] PathValues(BinaryNode<int> node, bool isRoot = true)
        {
            if (node is null) { return null; }
            else
            {
                if (isRoot && node.BreadthFirstSearch().OrderByDescending(n => n.Data).First().Data <= 0)
                {
                    BinaryNode<int>[] nodes = new BinaryNode<int>[] { node.BreadthFirstSearch().OrderByDescending(n => n.Data).First() };
                    return new BinaryTreePath[] { new BinaryTreePath(nodes, false) };
                }
                else
                {
                    var ret = new List<BinaryTreePath>() { new BinaryTreePath(new BinaryNode<int>[] { node }, true) };
                    var left = new BinaryTreePath[] { }; ;
                    var leftBranches = new BinaryTreePath[] { };
                    var right = new BinaryTreePath[] { }; ;
                    var rightBranches = new BinaryTreePath[] { }; ;
                    if (TryFindSubBranches(node.Left, out left))
                    {
                        ret.AddRange(ExtractBranchReturnAllAsOrphan(left, out leftBranches));
                        foreach (var branch in leftBranches)
                        {
                            ret.Add(new BinaryTreePath(branch, node));
                        }
                    }
                    if (TryFindSubBranches(node.Right, out right))
                    {
                        ret.AddRange(ExtractBranchReturnAllAsOrphan(right, out rightBranches));
                        foreach (var branch in rightBranches)
                        {
                            ret.Add(new BinaryTreePath(branch, node));
                        }
                    }
                    foreach (var leftBranch in leftBranches)
                    {
                        foreach (var rightBranch in rightBranches)
                        {
                            ret.Add(new BinaryTreePath(leftBranch, node, rightBranch));
                        }
                    }
                    return ret.ToArray();
                }
            }
        }

        private static IEnumerable<BinaryTreePath> ExtractBranchReturnAllAsOrphan(BinaryTreePath[] leaves, out BinaryTreePath[] branches)
        {
            branches = leaves.Where(s => s.IsBranch).ToArray();
            return leaves.Select(b => new BinaryTreePath(b.Nodes, false));
        }

        private static bool TryFindSubBranches(BinaryNode<int> branch, out BinaryTreePath[] subPaths)
        {
            if (branch is null)
            {
                subPaths = null;
                return false;
            }
            else
            {
                subPaths = PathValues(branch, false);
                return true;
            }
        }
    }
}