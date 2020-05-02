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
            bool keepGoing = true;
            while (keepGoing)
            {
                keepGoing = aCur?.Next != null || bCur?.Next != null;
                current.Value += aCur?.Value ?? 0;
                current.Value += bCur?.Value ?? 0;
                if (current.Value >= 10 || keepGoing)
                {
                    current.Next = new SinglyLinkedListNode<int>(current.Value / 10);
                    current.Value %= 10;
                }
                current = current.Next;
                aCur = aCur?.Next;
                bCur = bCur?.Next;
            }
            return ret;
        }
    }
}