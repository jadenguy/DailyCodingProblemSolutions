using System;
using Common.Node;

namespace Common
{
    public static class Solution026

    {
        public static void RemoveNthLastElement(SinglyLinkedListNode<int> list, int wanted)
        {
            var x = list;
            var y = list;
            for (int i = 0; i <= wanted; i++)
            {
                x = x.Next;
            }
            // System.Diagnostics.Debug.WriteLine(x?.Print());
            while (x != null && x.Next != null)
            {
                x = x.Next;
                y = y.Next;
            }
            y.Next = y.Next.Next;
        }
    }
}