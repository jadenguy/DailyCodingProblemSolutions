using System;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution083
    {
        public static BinaryNode<string> Invert(BinaryNode<string> node)
        {
            System.Collections.Generic.IEnumerable<BinaryNode<string>> pOrder = node.PreOrderReverseChildren();
            System.Collections.Generic.IEnumerable<BinaryNode<string>> iOrder = node.OutOrder();
            return Solution048.Reconstruct(pOrder, iOrder);
        }
    }
}