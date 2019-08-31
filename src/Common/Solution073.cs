// Given the head of a singly linked list, reverse it in-place.

using Common.Node;

namespace Common
{
    public class Solution073
    {
        public static LinkedListNode ReverseLinkedList(LinkedListNode x)
        {
            LinkedListNode next = null, previous = null, current = x;
            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            return previous;
        }
    }
}