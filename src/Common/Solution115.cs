using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution115
    {
        public static bool BSTContainsBST(BinaryNode<int> a, BinaryNode<int> b)
        {
            return a.BreadthFirstSearch().ToList().Contains(b);
        }
    }
}