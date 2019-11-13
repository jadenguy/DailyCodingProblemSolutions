using System;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution083
    {
        public static BinaryNode<string> Invert(BinaryNode<string> node)
        {
            return Solution048.Reconstruct(node.PreOrder(), node.OutOrder());
        }
    }
}