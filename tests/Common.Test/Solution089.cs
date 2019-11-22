using System;
using System.Linq;
using Common.Node;

namespace Common
{
    internal class Solution089
    {
        internal static bool IsBST(BinaryNode<int> node)
        {
            var InOrder = node.InOrder().Select(v => v.Data).ToArray();
            var Sorted = node.BreadthFirstSearch().Select(v => v.Data).OrderBy(v => v);
            return InOrder.Except(Sorted).Any();
        }
    }
}