using System;
using System.Linq;
using Common.Node;

namespace Common
{
    internal class Solution089
    {
        internal static bool IsBST(BinaryNode<int> node)
        {
            if (node.BreadthFirstSearch().Select(v => v.Data).Count() != node.BreadthFirstSearch().Select(v => v.Data).Distinct().Count()) { return false; }
            var InOrder = node.InOrder().Select(v => v.Data).ToArray();
            var Sorted = node.BreadthFirstSearch().Select(v => v.Data).OrderBy(v => v).ToArray();
            return !InOrder.SequenceEqual(Sorted);
        }
    }
}