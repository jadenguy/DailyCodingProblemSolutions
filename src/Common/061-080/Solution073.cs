using Common.Node;

namespace Common
{
    public class Solution073
    {
        public static SinglyLinkedListNode<int> ReverseLinkedList(SinglyLinkedListNode<int> x)
        {
            SinglyLinkedListNode<int> next = null, previous = null, current = x;
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