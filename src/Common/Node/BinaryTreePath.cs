using System;
using System.Linq;

namespace Common.Node
{
    public class BinaryTreePath
    {
        public BinaryNode<int>[] Nodes { get; }
        public bool IsBranch { get; }
        public BinaryTreePath(BinaryNode<int>[] nodes, bool isBranch)
        {
            this.Nodes = nodes;
            this.IsBranch = isBranch;
        }
        public BinaryTreePath(BinaryTreePath left, BinaryNode<int> root, BinaryTreePath right = null)
        {
            if (root is null) { throw new ArgumentNullException(nameof(root)); }
            if (right is null)
            {
                Nodes = left.Nodes.Union(new BinaryNode<int>[] { root }).ToArray();
                IsBranch = true;
            }
            else
            {
                Nodes = left.Nodes.Union(new BinaryNode<int>[] { root }).Union(right.Nodes.Reverse()).ToArray();
                IsBranch = false;
            }
        }
        public int Sum() => Nodes?.Sum(n => n.Value) ?? 0;
        public override string ToString() => $"{IsBranch.ToString()} {Nodes.Length} {Sum()}";
    }
}