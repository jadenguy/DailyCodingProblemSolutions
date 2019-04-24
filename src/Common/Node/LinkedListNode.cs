using System.Collections.Generic;

namespace Common.Node
{
    public class LinkedListNode : INode<LinkedListNode>
    {
        public LinkedListNode(string value, LinkedListNode next = null)
        {
            this.Next = next;
            this.Value = value;
        }
        public LinkedListNode Next { get; set; }
        public string Value { get; set; }

        public IEnumerable<LinkedListNode> Children()
        {
            yield return Next;
        }
    }
}