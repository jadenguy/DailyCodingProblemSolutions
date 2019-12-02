using System;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution093
    {
        public static BinaryNode<int> LargestBST(BinaryNode<int> node)
        {
            return node.PreOrder().Where(x => Solution089.IsBST(x)).OrderByDescending(n => n.BreadthFirstSearch().Count()).FirstOrDefault();
        }
    }
}