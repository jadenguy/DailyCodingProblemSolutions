using System;
using System.Linq;

namespace Common
{
    public static class Solution131
    {
        public static SinglePlusRandomLinkedListNode<int> DeepClone(this SinglePlusRandomLinkedListNode<int> original)
        {
            var originalArray = original.BreadthFirstSearch().Select(n => (SinglePlusRandomLinkedListNode<int>)n).ToArray();
            var clone = original.BreadthFirstSearch().Select(n => new SinglePlusRandomLinkedListNode<int>(n.Value, n.Name)).ToArray();

            for (int i = 0; i < clone.Count(); i++)
            {
                clone[i].Next = findInCopy(originalArray, clone, originalArray[i].Next);
                clone[i].Other = findInCopy(originalArray, clone, originalArray[i].Other);
            }
            return clone.FirstOrDefault();
        }
        private static SinglePlusRandomLinkedListNode<int> findInCopy(SinglePlusRandomLinkedListNode<int>[] originalArray, SinglePlusRandomLinkedListNode<int>[] clone, SinglePlusRandomLinkedListNode<int> next) => (next is null) ? null : clone[Array.FindIndex(originalArray, p => p.Equals(next))];
    }
}