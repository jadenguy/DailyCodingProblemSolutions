using System;
using System.Collections.Generic;

namespace Common.Node
{
    public class ParentAwareBSTNode<T> : BinarySearchNode<T> where T : IComparable<T>
    {
        public ParentAwareBSTNode<T> Parent { get; set; }
        public ParentAwareBSTNode()
        {
        }

        public ParentAwareBSTNode(T value, ParentAwareBSTNode<T> left = null, ParentAwareBSTNode<T> right = null, string name = "Root") : base(value, left, right, name)
        {
        }
        public override BinaryNode<T> Left
        {
            get => ((ParentAwareBSTNode<T>)(base.Left)); set
            {
                var value1 = (ParentAwareBSTNode<T>)value;
                base.Left = value1;
                value1.Parent = this;
            }
        }
        public override BinaryNode<T> Right
        {
            get => ((ParentAwareBSTNode<T>)(base.Right)); set
            {
                var value1 = (ParentAwareBSTNode<T>)value;
                base.Right = value1;
                value1.Parent = this;
            }
        }
        public override IEnumerable<BinaryNode<T>> BreadthFirstSearch()
        {
            return base.BreadthFirstSearch();
        }
        public override IEnumerable<BinaryNode<T>> Children()
        {
            return base.Children();
        }
    }
}