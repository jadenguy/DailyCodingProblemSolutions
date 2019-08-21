using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Node;

namespace Common
{
    public static class Solution048
    {
        public static BinaryNode<T> Reconstruct<T>(IEnumerable<BinaryNode<T>> preOrder, IEnumerable<BinaryNode<T>> inOrder)
        {
            int iLength = inOrder.Count();
            if (iLength == 0) { return null; }
            int pLength = preOrder.Count();
            BinaryNode<T> potentialRoot = null;
            bool foundRoot = false;
            for (int p = 0; !foundRoot && p < pLength; p++)
            {
                potentialRoot = preOrder.ElementAtOrDefault(p);
                // if we have a left or right half of an in-order, 
                // the root of that half is one of the first two 
                // elements in the pre-order, we don't know which
                // one yet. try until you find a root node in the
                // in-order collection.
                for (int i = 0; !foundRoot && i < iLength; i++)
                {
                    var current = inOrder.ElementAt(i);
                    foundRoot = current.Data.Equals(potentialRoot.Data);
                    if (foundRoot)
                    {
                        var leftNChildren = inOrder.Take(i);
                        var rightNChildren = inOrder.TakeLast(iLength - i - 1);
                        var resOfPreOrder = preOrder.TakeLast(pLength - p - 1);
                        potentialRoot.Left = Reconstruct(resOfPreOrder, leftNChildren);
                        potentialRoot.Right = Reconstruct(resOfPreOrder, rightNChildren);
                    }
                }
            }
            if (!foundRoot) { return null; }
            return potentialRoot;
        }
    }
}