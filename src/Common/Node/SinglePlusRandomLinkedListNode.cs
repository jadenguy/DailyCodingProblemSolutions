using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Node;

namespace Common
{
    public class SinglePlusLinkComparer<T> : EqualityComparer<SinglePlusRandomLinkedListNode<T>> where T : IEquatable<T>
    {
        public override bool Equals(SinglePlusRandomLinkedListNode<T> x, SinglePlusRandomLinkedListNode<T> y)
        {
            var a = x.BreadthFirstSearch().ToDictionary(k => k, v => ((SinglePlusRandomLinkedListNode<T>)v).Next);
            var b = y.BreadthFirstSearch();
            return false;
        }
        public override int GetHashCode(SinglePlusRandomLinkedListNode<T> obj) => obj.BreadthFirstSearch().Print("->").ToString().GetHashCode();
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