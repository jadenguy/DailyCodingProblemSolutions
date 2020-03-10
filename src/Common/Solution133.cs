using Common.Node;

namespace Common
{
    public static class Solution133
    {
        public static BinaryNode<int> FindSuccessor(BinaryNode<int> leaf)
        {
            var current = leaf;
            if (leaf.Right != null)
            {
                current = (BinaryNode<int>)current.Right;
                while (current.Left != null)
                { current = (BinaryNode<int>)current.Left; }
                return current;
            }
            else
            {
                while (ReferenceEquals(current.Parent?.Right, current)) { current = current.Parent; }
                return current?.Parent;
            }
        }
    }
}