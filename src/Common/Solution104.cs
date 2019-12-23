using System.Collections.Generic;

namespace Common
{
    public class Solution104
    {
        public static bool IsDoubleLinkListAPalindrome(string text) => IsLinkedListAPalindrome(text); // There's no reason to make it any harder
        public static bool IsLinkedListAPalindrome(string text)
        {
            var ret = true;
            var list = new LinkedList<char>(text);
            var current = list.First;
            var x = new Queue<char>();
            var y = new Stack<char>();
            while (current != null)
            {
                x.Enqueue(current.Value);
                y.Push(current.Value);
                current = current.Next;
            }
            var listLength = x.Count;
            while (ret && x.Count > listLength / 2)
            {
                var l = x.Dequeue();
                var r = y.Pop();
                ret = l.Equals(r);
            }
            return ret;
        }
    }
}