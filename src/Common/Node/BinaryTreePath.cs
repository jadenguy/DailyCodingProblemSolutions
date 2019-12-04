using System;
using System.Linq;
using Common.Node;

namespace Common
{

    public class BinaryTreePath
    {
        private BinaryNode<int>[] nodes;
        public BinaryTreePath(BinaryNode<int>[] nodes, bool type)
        {
            this.Nodes = nodes;
            this.IsBranch = type;
        }
        public BinaryNode<int>[] Nodes { get => nodes; set => nodes = value; }
        public BinaryTreePath(BinaryTreePath left, BinaryNode<int> root, BinaryTreePath right = null)
        {
            if (root is null) { throw new ArgumentNullException(nameof(root)); }
            Nodes = left.Nodes.Union(new BinaryNode<int>[] { root }).Union(right.Nodes.Reverse()).ToArray();
            switch (right)
            {
                case null:
                    // Nodes = left.Nodes.Union(new BinaryNode<int>[] { root }).ToArray();
                    IsBranch = true;
                    break;
                default:
                    
                    IsBranch = false;
                    break;
            }
        }
        public bool IsBranch { get; set; }
        public int Sum() => Nodes?.Sum(n => n.Data) ?? 0;
        public override string ToString() => $"{IsBranch.ToString()} {Nodes.Length} {Sum()}";
    }
}
