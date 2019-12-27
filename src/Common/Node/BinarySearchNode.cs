using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Node
{
    public class BinarySearchNode<T> : BinaryNode<T>, IComparable<BinarySearchNode<T>> where T : IComparable<T>
    {
        public BinarySearchNode() : base() { }
        public BinarySearchNode(T value, BinarySearchNode<T> left = null, BinarySearchNode<T> right = null, string name = "Root") : base(value, left, right, name)
        {
            Value = value;
            Left = null;
            Right = null;
        }
        public static BinarySearchNode<T> GenerateBinarySearchNode(IEnumerable<T> sequence)
        {
            var array = sequence.ToArray();
            if (array.Length > 0)
            {
                var ret = new BinarySearchNode<T>(array[0]);
                ret.Add(array.Skip(1));
                return ret;
            }
            return null;
        }
        private void Add(IEnumerable<BinaryNode<T>> enumerable) => Add(enumerable.Select(v => v.Value));
        public void Add(IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
            {
                this.Add(item);
            }
        }
        public void Add(T item)
        {
            if (item.Equals(Value))
            { throw new ArgumentException("Value exists in tree"); }
            if (item.CompareTo(Value) < 0)
            {
                if (Left is null)
                {
                    Left = new BinarySearchNode<T>(item);
                }
                else { ((BinarySearchNode<T>)Left).Add(item); }
            }
            else
            {
                if (Right is null)
                {
                    Right = new BinarySearchNode<T>(item);
                }
                else { ((BinarySearchNode<T>)Right).Add(item); }
            }
        }
        public int CompareTo(BinarySearchNode<T> other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
