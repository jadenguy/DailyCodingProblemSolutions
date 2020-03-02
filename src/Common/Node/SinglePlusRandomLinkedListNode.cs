using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Node;

namespace Common
{
    public class SinglePlusLinkComparer<T> : IEqualityComparer<SinglePlusRandomLinkedListNode<T>> where T : IEquatable<T>
    {
        public bool Equals(SinglePlusRandomLinkedListNode<T> x, SinglePlusRandomLinkedListNode<T> y)
        {
            var a = x.BreadthFirstSearch().Select(n => ((SinglePlusRandomLinkedListNode<T>)n).Next).ToArray();
            var b = y.BreadthFirstSearch().Select(n => ((SinglePlusRandomLinkedListNode<T>)n).Next).ToArray();
            var c = x.BreadthFirstSearch().Select(n => ((SinglePlusRandomLinkedListNode<T>)n).Other).ToArray();
            var d = y.BreadthFirstSearch().Select(n => ((SinglePlusRandomLinkedListNode<T>)n).Other).ToArray();
            return false;
        }
        public int GetHashCode(SinglePlusRandomLinkedListNode<T> obj) => obj.BreadthFirstSearch().Print("->").GetHashCode();
    }
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