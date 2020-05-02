using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public static class Solution135
    {
        public static IEnumerable<BinaryTreePath> CheapestPath(BinaryNode<int> root)
        {
            var enumerable = Solution094.PathValues(root);
            return enumerable.Where(n => Validate(root, n));
        }

        private static bool Validate(BinaryNode<int> root, BinaryTreePath n)
        {
            BinaryNode<int> binaryNode = n.Nodes.LastOrDefault();
            bool v = binaryNode == root;
            BinaryNode<int> binaryNode1 = n.Nodes.FirstOrDefault();
            bool v1 = !binaryNode1.Children().Any();
            return v && v1;
        }
    }
}