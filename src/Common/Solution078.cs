using System.Collections.Generic;
using System.Linq;
using Common.Node;

namespace Common
{
    public class Solution078
    {
        public static LinkedListNode MergeSortedLinkedList(IEnumerable<LinkedListNode> nodes)
        {
            var ret = new List<int>();
            var dict = Enumerable.Range(0, nodes.Count()).ToDictionary(k => k, v => nodes.ElementAt(v));
            var totalElements = dict.Sum(x => x.Value.Count());
            for (int i = 0; i < totalElements; i++)
            {
                var earliest = dict.OrderBy(x => x.Value?.Value ?? int.MaxValue).First();
                ret.Add(earliest.Value.Value);
                dict[earliest.Key] = earliest.Value.Next;
            }
            return new Node.LinkedListNode(ret);
        }
    }
}