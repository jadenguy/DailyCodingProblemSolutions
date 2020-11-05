using Common.Node;

namespace Common
{
    public static class Solution145
    {
        public static SinglyLinkedListNode<T> FlipEveryTwo<T>(SinglyLinkedListNode<T> node)
        {
            var current = node;
            bool hasSecond = (current?.Next ?? null) != null;
            if (hasSecond)
            {
                var ret = current.Next;
                while (hasSecond)
                {
                    var newHead = current.Next;
                    current = (current?.Next ?? null);
                    hasSecond = (current?.Next ?? null) != null;
                }
                return ret;
            }
            else { return node; }
        }
    }
}