using System;
using System.Collections;
using System.Collections.Generic;

namespace Common.Node
{
    public class SinglyLinkedListNode<T> : Node<SinglyLinkedListNode<T>>, IEnumerable<SinglyLinkedListNode<T>>, IEquatable<SinglyLinkedListNode<T>>
    {
        private SinglyLinkedListNode<T> next;
        public SinglyLinkedListNode(IEnumerable<T> list)
        {
            var enumerator = list.GetEnumerator();
            if (enumerator.MoveNext())
            {
                this.Value = enumerator.Current;
                var add = this;
                while (enumerator.MoveNext())
                {
                    add.Next = new SinglyLinkedListNode<T>(enumerator.Current);
                    add = add.Next;
                }
            }
        }
        public SinglyLinkedListNode(T value)
        {
            this.Value = value;
        }
        public SinglyLinkedListNode<T> Next
        {
            get => next;
            set
            {
                next = value;
            }
        }
        public T Value { get; set; }
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
        public SinglyLinkedListNode<T> this[int x]
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
        public override IEnumerable<SinglyLinkedListNode<T>> Children()
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
        public IEnumerator<SinglyLinkedListNode<T>> GetEnumerator() => BreadthFirstSearch().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => BreadthFirstSearch().GetEnumerator();

        [System.Diagnostics.DebuggerStepThrough] public bool Equals(SinglyLinkedListNode<T> other) => this.Next == other.Next;
    }
}