using System;
using System.Linq;
using System.Collections.Generic;


namespace Common.Node
{
    public class BinaryNode<T> : Node<BinaryNode<T>>, IEquatable<BinaryNode<T>>
    {
        public BinaryNode(T value, BinaryNode<T> left = null, BinaryNode<T> right = null, string name = "Root")
        {
            this.Data = value;
            this.Left = left;
            this.Right = right;
            this.Name = name;
        }
        public BinaryNode(BinaryNode<T> node)
        {
            this.Data = node.Data;
            this.Name = node.Name;
        }
        public T Data { get; set; }
        public string Name { get; set; }
        private BinaryNode<T> left;
        private BinaryNode<T> right;
        public virtual BinaryNode<T> Left
        {
            get => left;
            set
            {
                if (value != null)
                {
                    left = value;
                    left.Name = this.Name + ".Left";
                }
            }
        }
        public virtual BinaryNode<T> Right
        {
            get => right;
            set
            {
                if (value != null)
                {
                    right = value;
                    right.Name = this.Name + ".Right";
                }
            }
        }
        public override IEnumerable<BinaryNode<T>> Children()
        {
            if (Left != null) { yield return Left; }
            if (Right != null) { yield return Right; }
        }
        public override string ToString() => Name + " " + Data;
        public IEnumerable<BinaryNode<T>> InOrder()
        {
            if (Left != null)
            {
                foreach (var item in Left.InOrder())
                {
                    yield return item;
                }
            }
            yield return this;
            if (Right != null)
            {
                foreach (var item in Right.InOrder())
                {
                    yield return item;
                }
            }
        }
        public IEnumerable<BinaryNode<T>> OutOrder()
        {
            if (Right != null)
            {
                foreach (var item in Right.InOrder())
                {
                    yield return item;
                }
            }
            yield return this;
            if (Left != null)
            {
                foreach (var item in Left.InOrder())
                {
                    yield return item;
                }
            }
        }
        [System.Diagnostics.DebuggerStepThrough]
        public bool Equals(BinaryNode<T> other)
        {
            if (other is null) { return false; }

            bool sameName = this.Name.Equals(other.Name);
            bool sameData = this.Data.Equals(other.Data);
            bool sameChildren = true;

            if (this.Left != null || other.Left != null) { sameChildren &= this.Left != null && this.Left.Equals(other.Left); }
            if (this.Right != null || other.Right != null) { sameChildren &= this.Right != null && this.Right.Equals(other.Right); }

            return sameName && sameData && sameChildren;
        }
    }
}