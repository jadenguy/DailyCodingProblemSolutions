using System;
using System.Linq;
using Common.Node;

namespace Common
{

    public class BinaryTreePath
    {
        public enum PathType
        {
            Orphan, Branch, FullPath
        }
        private BinaryNode<int>[] nodes;
        public BinaryTreePath(BinaryNode<int>[] nodes, PathType type)
        {
            this.Nodes = nodes;
            this.Type = type;
        }
        public BinaryNode<int>[] Nodes { get => nodes; set => nodes = value; }
        public BinaryTreePath(BinaryTreePath left, BinaryNode<int> root, BinaryTreePath right = null)
        {
            if (root is null) { throw new ArgumentNullException(nameof(root)); }
            var newPath = left.Nodes.Union(new BinaryNode<int>[] { root });
            bool hasLeft = left != null;
            bool hasRight = right != null;
            bool hasBoth = hasLeft && hasRight;
            if (hasBoth) { Type = PathType.FullPath; }
            else
            {
                Type = PathType.Branch;
                if (hasLeft) { newPath = left.Nodes.Union(newPath); }
                if (hasRight) { newPath = newPath.Union(right.Nodes.Reverse()); }
            }
            Nodes = newPath.ToArray();
        }
        public PathType Type { get; set; }
        public int Sum() => Nodes?.Sum(n => n.Data) ?? 0;
    }
}
