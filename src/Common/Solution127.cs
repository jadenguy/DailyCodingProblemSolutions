using Common.Node;

namespace Common
{
    public static class Solution127
    {
        public static SinglyLinkedListNode<int> AddReverseDigitLinkedList(SinglyLinkedListNode<int> a, SinglyLinkedListNode<int> b)
        {
            var ret = new SinglyLinkedListNode<int>(0);
            var current = ret;
            var aCur = a;
            var bCur = b;
            do
            {
                int aInt = a?.Next?.Value ?? 0;
                int bInt = b?.Next?.Value ?? 0;
                int v = (aInt + bInt);
                current.Value += v % 10;
                current.Next = new SinglyLinkedListNode<int>(v / 10);
                current = current.Next;
            } while (aCur?.Next != null || bCur?.Next != null);
            return ret;
        }
    }
}