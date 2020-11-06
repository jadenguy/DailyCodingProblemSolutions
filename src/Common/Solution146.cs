using System;
using System.Linq;
using Common.Node;

namespace Common
{
    public static class Solution146
    {
        public static BinaryNode<int> Prune(BinaryNode<int> node)
        {
            if (node is null) { return null; }

            BinaryNode<int> newLeft = Prune(node.Left);
            node.Left = newLeft;
            BinaryNode<int> newRight = Prune(node.Right);
            node.Right = newRight;
            var prune = (node.Left is null && node.Right is null && node.Value == 0);
            BinaryNode<int> ret = prune ? null : node;
            return ret;
        }
    }
}