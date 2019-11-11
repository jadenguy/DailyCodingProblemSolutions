using System;
using System.Collections;
using System.Collections.Generic;

namespace Common.Node
{
    public class LinkedListNode : Node<LinkedListNode>, IEnumerable<LinkedListNode>, IEquatable<LinkedListNode>
    {
        private LinkedListNode next;
        public LinkedListNode(IEnumerable<int> list)
        {
            var enumerator = list.GetEnumerator();
            if (enumerator.MoveNext())
            {
                this.Value = enumerator.Current;
                var add = this;
                while (enumerator.MoveNext())
                {
                    add.Next = new LinkedListNode(enumerator.Current);
                    add = add.Next;
                }
            }
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
                next = value;
            }
        }
        public int Value { get; set; }
        public int Height
        {
            get
            {
                var ret = 0;
                foreach (var item in BreadthFirstSearch())
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
        public override IEnumerable<LinkedListNode> Children()
        {
            if (Next != null)
            {
                yield return Next;
            }
        }
        public override string ToString() => $"{Value} {Height}";
        public string Print()
        {
            var ret = string.Empty;
            var enumerator = BreadthFirstSearch().GetEnumerator();
            var height = this.Height;
            for (int i = 0; i < height; i++)
            {
                enumerator.MoveNext();
                ret += enumerator.Current.Value;
                if (i < height - 1) { ret += " => "; }
            }
            return ret;
        }
        public IEnumerator<LinkedListNode> GetEnumerator() => BreadthFirstSearch().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => BreadthFirstSearch().GetEnumerator();

        [System.Diagnostics.DebuggerStepThrough] public bool Equals(LinkedListNode other) => this.Next == other.Next;
    }
}