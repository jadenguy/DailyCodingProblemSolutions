// Given the head of a singly linked list, reverse it in-place.

using Common.Node;

namespace Common
{
    internal class Solution073
    {
        internal static LinkedListNode ReverseLinkedList(LinkedListNode x)
        {
            LinkedListNode next = null, previous = null, current = x;
            do
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            } while (next != null);
            return previous;
        }
    }
}