using System.Linq;
using Common.Node;

namespace Common
{
    public static class Solution115
    {
        public static bool BSTContainsBST(this BinaryNode<int> a, BinaryNode<int> b)
        {
            return a.BreadthFirstSearch().Contains(b);
        }
    }
}