using System;
using System.Collections.Generic;
using Common.Node;

namespace Common
{
    public class SinglePlusRandomLinkedListNode<T> : GraphNode<T> where T : IEquatable<T>
    {
        public SinglePlusRandomLinkedListNode<T> Next { get; set; }
        public SinglePlusRandomLinkedListNode<T> Other { get; set; }
        public SinglePlusRandomLinkedListNode(T value) : base(value) { }
        public SinglePlusRandomLinkedListNode(T value, string name) : base(value, name) { }
        public override IEnumerable<GraphNode<T>> Children()
        {
            if (Next != null) { yield return Next; }
            if (Other != null) { yield return Other; }
        }
    }
}