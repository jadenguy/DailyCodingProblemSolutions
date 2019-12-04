using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution094
    {
        private const BinaryTreePath.PathType LEAF = BinaryTreePath.PathType.Leaf;
        private const BinaryTreePath.PathType BRANCH = BinaryTreePath.PathType.Branch;
        private const BinaryTreePath.PathType FULL =  BinaryTreePath.PathType.FullPath;
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