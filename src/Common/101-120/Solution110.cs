using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public static class Solution110
    {
        public static IEnumerable<IEnumerable<int>> EnumerateBranches(this BinaryNode<int> node, IEnumerable<int> parent = null)
        {
            var ret = new List<int>(parent ?? new int[0]) { node.Value };
            if (node.Children().Any()) { return node.Children().SelectMany(n => n.EnumerateBranches(ret)); }
            else { return new int[][] { ret.ToArray() }; }
        }
    }
}