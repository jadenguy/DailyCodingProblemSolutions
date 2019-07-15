using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Node
{
    public class BinarySearchNode : BinaryNode<int>, IComparable<BinarySearchNode>
    {
        public new BinarySearchNode Left;
        public new BinarySearchNode Right;
        public BinarySearchNode(int value, BinarySearchNode left = null, BinarySearchNode right = null, string name = "Root") : base(value, left, right, name)
        {
            Value = value;
            Left = null;
            Right = null;
            // if (left != null) { this.Add(left.InOrder()); }
            // if (right != null) { this.Add(right.InOrder().Select(k => (BinarySearchNode)k).ToArray()); }
        }
        private void Add(IEnumerable<BinaryNode<int>> enumerable) => Add(enumerable.Select(v => v.Value));
        public void Add(IEnumerable<int> enumerable)
        {
            foreach (var item in enumerable)
            {
                this.Add(item);
            }
        }
        public void Add(int item)
        {
            if (item == Value)
            { throw new ArgumentException("Value exists in tree"); }
            if (item < Value)
            {
                if (Left == null)
                {
                    Left = new BinarySearchNode(item);
                }
                else { Left.Add(item); }
            }
            else
            {
                if (Right == null)
                {
                    Right = new BinarySearchNode(item);
                }
                else { Right.Add(item); }
            }
        }
        public int CompareTo(BinarySearchNode other) => Value.CompareTo(other.Value);
    }
}
