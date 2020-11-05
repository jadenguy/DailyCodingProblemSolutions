using Common.Node;

namespace Common
{
    public static class Solution145
    {
        public static SinglyLinkedListNode<T> FlipEveryTwo<T>(SinglyLinkedListNode<T> node)
        {
            var current = node;
            int listLength = node?.Height ?? 0;
            var ret = node;
            if (listLength >= 2)
            {
                ret = node.Next;
                for (int i = 0; i < listLength / 2; i++)
                {
                    var x = current.Next;
                    var nextTail = x.Next;
                    current.Next.Next = current;
                    current.Next = x;
                    current = nextTail;
                }
            }
            return ret;
        }
    }
}