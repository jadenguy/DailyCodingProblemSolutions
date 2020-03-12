using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution094
    {
        public static IEnumerable<BinaryTreePath> PathValues(BinaryNode<int> node) => PathValues(node, true);
        private static IEnumerable<BinaryTreePath> PathValues(BinaryNode<int> node, bool isRoot)
        {
            if (node is null) { return null; }
            else
            {
                if (isRoot && node.BreadthFirstSearch().OrderByDescending(n => n.Value).First().Value <= 0)
                {
                    BinaryNode<int>[] nodes = new BinaryNode<int>[] { node.BreadthFirstSearch().OrderByDescending(n => n.Value).ThenBy(n => n.Name).First() };
                    return new BinaryTreePath[] { new BinaryTreePath(nodes, false) };
                }
                else
                {
                    var ret = new List<BinaryTreePath>() { new BinaryTreePath(new BinaryNode<int>[] { node }, true) };
                    IEnumerable<BinaryTreePath> leftBranches = new BinaryTreePath[] { }, rightBranches = new BinaryTreePath[] { }, left, right;
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
                    return ret;
                }
            }
        }
        private static IEnumerable<BinaryTreePath> ExtractBranchReturnAllAsOrphan(IEnumerable<BinaryTreePath> leaves, out IEnumerable<BinaryTreePath> branches)
        {
            branches = leaves.Where(s => s.IsBranch);
            return leaves.Select(b => new BinaryTreePath(b.Nodes, false));
        }
        private static bool TryFindSubBranches(BinaryNode<int> branch, out IEnumerable<BinaryTreePath> subPaths)
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