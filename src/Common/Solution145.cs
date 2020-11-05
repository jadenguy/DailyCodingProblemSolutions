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
                var odd = new SinglyLinkedListNode<T>(default(T));
                var oddTop = odd;
                var even = new SinglyLinkedListNode<T>(default(T));
                var evenTop = even;
                var final = new SinglyLinkedListNode<T>(default(T));
                var finalTop = final;
                for (int i = 0; i < listLength; i += 2)
                {
                    var next = current.Next?.Next;

                    var nextOdd = current;
                    var nextEven = current?.Next;
                    nextOdd.Next = null;
                    if (!(nextEven is null))
                    { nextEven.Next = null; }

                    odd.Next = nextOdd;
                    even.Next = nextEven;

                    odd = odd?.Next;
                    even = even?.Next;
                    current = next;
                }
                even = evenTop.Next;
                odd = oddTop.Next;
                for (int i = 0; i < listLength; i += 2)
                {
                    var nextEven = even?.Next;
                    var nextOdd = odd?.Next;
                    final.Next = even;
                    if (!(even is null))
                    { final.Next.Next = odd; }
                    else { final.Next = odd; }
                    odd = nextOdd;
                    even = nextEven;
                    final = final?.Next?.Next;
                }
                ret = finalTop.Next;
            }
            return ret;
        }
    }
}
