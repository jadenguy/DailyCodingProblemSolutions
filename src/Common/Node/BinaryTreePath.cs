using System;
using System.Linq;
using Common.Node;

namespace Common
{

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
        public BinaryTreePath(BinaryTreePath branchA, BinaryNode<int> root, BinaryTreePath branchB = null)
        {
            if (branchA is null || root is null) { throw new ArgumentNullException(nameof(root)); }
            var newPath = branchA.Nodes.Union(new BinaryNode<int>[] { root });
            Type = PathType.Branch;
            if (branchB is null)
            { Type = PathType.FullPath; }
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
}
