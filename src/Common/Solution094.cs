using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution094
    {
        private const BinaryTreePath.PathType LEAF = BinaryTreePath.PathType.Leaf;
        public class BinaryTreePath
        {
            public enum PathType
            {
                Leaf, Branch, FullPath
            }
            private BinaryNode<int>[] nodes;
            public BinaryTreePath(BinaryNode<int>[] nodes, PathType type)
            {
                this.Nodes = nodes;
                this.Type = type;
            }
            public BinaryNode<int>[] Nodes { get => nodes; set => nodes = value; }
            public PathType Type { get; set; }
            public int Sum() => Nodes.Sum(n => n.Data);
        }
        public static IEnumerable<BinaryTreePath> MaxPathSum(BinaryNode<int> node, bool isParent = true)
        {
            if (node == null)
            { yield return new BinaryTreePath(new BinaryNode<int>[] { }, LEAF); }
            else
            {
                var rankedNodes = node.BreadthFirstSearch().OrderBy(n => n.Data);
                var largestNode = rankedNodes.First();
                if (largestNode.Data <= 0) { yield return new BinaryTreePath(new BinaryNode<int>[] { largestNode }, LEAF); }
                else
                {
                    var children = node.Children().SelectMany(n => MaxPathSum(n, false)).ToArray();
                    var enumerable = children.OrderByDescending(v => v).Where(k => k.Sum() >= 0);
                    //     var childSum = enumerable.Sum();
                    //     var maxCountingNode = node.Data + childSum;
                    //     if (maxCountingNode < 0 && !isParent) { return enumerable.Max(); }
                    //     else if (maxCountingNode > childSum) { return maxCountingNode; }
                    //     else if (node.Data > childSum) { return node.Data; }
                    //     else { return childSum; }
                    throw new System.Exception("Need to finish this");

                }
            }
        }
    }
}