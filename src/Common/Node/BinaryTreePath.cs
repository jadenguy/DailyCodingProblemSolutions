using System;
using System.Linq;
using Common.Node;

namespace Common
{

    public class BinaryTreePath
    {
        private BinaryNode<int>[] nodes;
        public BinaryNode<int>[] Nodes { get => nodes; set => nodes = value; }
        public bool IsBranch { get; set; }
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
        public int Sum() => Nodes?.Sum(n => n.Data) ?? 0;
        public override string ToString() => $"{IsBranch.ToString()} {Nodes.Length} {Sum()}";
    }
}