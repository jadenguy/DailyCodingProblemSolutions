using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Node
{
    public class LinkedListNode : INode<LinkedListNode>
    {
        private LinkedListNode next;

        public static LinkedListNode GenerateLinkedListNode(int[] nodes)
        {
            var ret = new LinkedListNode(nodes[0]);
            var add = ret;
            for (int i = 1; i < nodes.Length; i++)
            {
                add.Next = new LinkedListNode(nodes[i]);
                if (i > 0) { add = add.Next; }
            }
            return ret;
        }

        public LinkedListNode(int value, LinkedListNode next = null)
        {
            this.Next = next;
            this.Value = value;
        }

        public LinkedListNode Next
        {
            get => next;
            set
            {
                if (!Traverse().ToList().Select(x => x.Value).Contains(value.Value)) { next = value; }
                else { throw new ArgumentException("Linked list cannot loop."); }
            }
        }

        public int Value { get; set; }
        public int Height
        {
            get
            {
                var ret = 0;
                foreach (var item in Traverse())
                {
                    ret++;
                }
                return ret;
            }
        }

        public LinkedListNode this[int x]
        {
            get
            {
                var ret = this;
                for (int i = 0; i < x; i++)
                {
                    ret = ret.Next;
                }
                return ret;
                ;
            }
            set
            {
                this[x - 1].Next = value;
            }
        }
        public IEnumerable<LinkedListNode> Children()
        {
            if (Next != null)
            {
                yield return Next;
            }
        }
        public IEnumerable<LinkedListNode> Traverse()
        {
            var current = this;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }
        public override string ToString() => $"{Value} {Height}";
        public string Print()
        {
            var ret = string.Empty;
            var enumerator = Traverse().GetEnumerator();
            var height = this.Height;
            for (int i = 0; i < height; i++)
            {
                enumerator.MoveNext();
                ret += enumerator.Current.Value;
                if (i < height - 1) { ret += " => "; }
            }
            return ret;
        }
    }
}