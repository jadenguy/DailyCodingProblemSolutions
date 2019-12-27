using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Node;

namespace Common
{
    public static class Solution048
    {
        public static BinaryNode<T> Reconstruct<T>(IEnumerable<BinaryNode<T>> preOrder, IEnumerable<BinaryNode<T>> inOrder, string name = null)
        {
            var pOrder = preOrder.ToArray(); //fixes too many traversals issue
            var iOrder = inOrder.ToArray();
            int iLength = iOrder.Count();
            if (iLength == 0) { return null; }
            int pLength = pOrder.Count();
            BinaryNode<T> potentialRoot = null;
            bool foundRoot = false;
            for (int p = 0; !foundRoot && p < pLength; p++)
            {
                potentialRoot = pOrder.ElementAtOrDefault(p).Copy(name);
                // if we have a left or right half of an in-order, 
                // the root of that half is one of the first two 
                // elements in the pre-order, we don't know which
                // one yet. try until you find a root node in the
                // in-order collection.
                for (int i = 0; !foundRoot && i < iLength; i++)
                {
                    foundRoot = iOrder.ElementAt(i).Value.Equals(potentialRoot.Value);
                    if (foundRoot)
                    {
                        var leftNChildren = iOrder.Take(i);
                        var rightNChildren = iOrder.TakeLast(iLength - i - 1);
                        var resOfPreOrder = pOrder.TakeLast(pLength - p - 1);
                        potentialRoot.Left = Reconstruct(resOfPreOrder, leftNChildren, potentialRoot.Name + ".Left");
                        potentialRoot.Right = Reconstruct(resOfPreOrder, rightNChildren, potentialRoot.Name + ".Right");
                    }
                }
            }
            if (!foundRoot) { return null; }
            return potentialRoot;
        }
    }
}