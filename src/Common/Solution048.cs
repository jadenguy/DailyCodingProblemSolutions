using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution048
    {
        public static BinaryNode<T> Reconstruct<T>(IEnumerable<BinaryNode<T>> preOrder, IEnumerable<BinaryNode<T>> inOrder)
        {
            int length = inOrder.Count();
            var root = preOrder.First();
            for (int i = 0; i < length; i++)
            {
                if (inOrder.ElementAt(i).Equals(root))
                {
                    root.Left = Reconstruct(preOrder.Take(i-1), inOrder.Take(i-1)); // not sure what the next step is, but it's something like this
                    root.Left = Reconstruct(preOrder.Reverse().Take(length - i - 1).Reverse(), inOrder.Reverse().Take(length - i - 1).Reverse()); //same
                }
            }
            return root;
        }
    }
}