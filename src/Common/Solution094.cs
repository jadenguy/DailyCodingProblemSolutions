using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution094
    {
        private const BinaryTreePath.PathType LEAF = BinaryTreePath.PathType.Leaf;
        private const BinaryTreePath.PathType BRANCH = BinaryTreePath.PathType.Branch;

        public class BinaryTreePath
        {
            public enum PathType
            {
                Leaf, Branch, FullPath
            }

            private const PathType FULL = PathType.FullPath;
            private BinaryNode<int>[] nodes;
            public BinaryTreePath(BinaryNode<int>[] nodes, PathType type)
            {
                this.Nodes = nodes;
                this.Type = type;
            }
            public BinaryNode<int>[] Nodes { get => nodes; set => nodes = value; }
            public BinaryTreePath(BinaryTreePath branchA, BinaryNode<int> root, BinaryTreePath branchB = null)
            {
                if (branchA is null || root is null) { throw new ArgumentNullException(nameof(root)); }
                var newPath = branchA.Nodes.Union(new BinaryNode<int>[] { root });
                Type = BRANCH;
                if (branchB is null)
                { Type = FULL; }
                else
                {
                    newPath = newPath.Union(branchB.Nodes.Reverse());
                }
                Nodes = newPath.ToArray();
            }
            public BinaryTreePath(BinaryTreePath results, BinaryNode<int> node, bool v)
            {
            }

            public PathType Type { get; set; }
            public int? Sum() => Nodes?.Sum(n => n.Data);
        }
        public static IEnumerable<BinaryTreePath> MaxPathSum(BinaryNode<int> node)
        {
            if (node is null) { yield break; }
            else
            {
                var rankedNodes = node.BreadthFirstSearch().OrderByDescending(n => n.Data);
                var largestNode = rankedNodes.First();
                if (true || largestNode.Data <= 0)
                {
                    yield return new BinaryTreePath(new BinaryNode<int>[] { largestNode }, LEAF);
                }
                else
                {
                    yield return new BinaryTreePath(new BinaryNode<int>[] { largestNode }, BRANCH);
                    var children = node.Children().Select(n => MaxPathSum(n)).ToArray();
                    foreach (var child in children)
                    {
                        foreach (var results in child)
                        {
                            if (results.Type == BRANCH)
                            {
                                yield return new BinaryTreePath(results, node);
                            }
                            results.Type = LEAF;
                            yield return results;
                        }
                    }
                    //     var maxCountingNode = node.Data + childSum;
                    //     if (maxCountingNode < 0 && !isParent) { return enumerable.Max(); }
                    //     else if (maxCountingNode > childSum) { return maxCountingNode; }
                    //     else if (node.Data > childSum) { return node.Data; }
                    //     else { return childSum; }
                    // throw new System.Exception("Need to finish this");
                }
            }
        }
    }
}