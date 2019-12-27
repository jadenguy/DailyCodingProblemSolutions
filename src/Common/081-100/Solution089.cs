using System;
using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public static class Solution089
    {
        public static bool IsBST(BinaryNode<int> node)
        {
            var allElements = node.BreadthFirstSearch().Data().OrderBy(v => v).ToArray();
            IEnumerable<int> distinctElements = allElements.Distinct();
            if (!allElements.SequenceEqual(distinctElements)) { return false; }
            var inOrderTraversalOfTree = node.InOrder().Data();
            return inOrderTraversalOfTree.SequenceEqual(allElements);
        }
        private static IEnumerable<T> Data<T>(this IEnumerable<BinaryNode<T>> enumerable) => enumerable.Select((Func<BinaryNode<T>, T>)(v => (T)v.Value));
    }
}