using System.Collections.Generic;

namespace Common
{
    public class Solution104
    {
        public static bool IsLinkedListAPalindrome(string text)
        {
            var ret = true;
            var list = new LinkedList<char>(text);
            var current = list.First;
            var q = new Queue<char>();
            var s = new Stack<char>();
            while (current != null)
            {
                q.Enqueue(current.Value);
                s.Push(current.Value);
                current = current.Next;
            }
            var listLength = q.Count;
            while (ret && q.Count > listLength / 2)
            {
                var l = q.Dequeue();
                var r = s.Pop();
                ret = l.Equals(r);
            }
            return ret;
        }
        public static bool IsDoubleLinkListAPalindrome(string text) => IsLinkedListAPalindrome(text); // There's no reason to make it any harder
    }
}