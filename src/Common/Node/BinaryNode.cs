using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace Common.Node
{
    [DataContract]
    public class BinaryNode<T> : Node<BinaryNode<T>>, IEquatable<BinaryNode<T>>
    {
        public BinaryNode() { }
        public BinaryNode(
            T data,
            BinaryNode<T> left = null,
            BinaryNode<T> right = null,
            string name = "Root",
            NodeDirection direction = NodeDirection.Root)
        {
            Value = data;
            Left = left;
            Right = right;
            Name = name;
            Direction = direction;
        }
        [JsonIgnore] public NodeDirection Direction { get; set; }
        [JsonIgnore] public BinaryNode<T> Parent { get; set; }
        [DataMember] public T Value { get; set; }
        [JsonIgnore] public T Data { get => Value; set => Value = value; }
        [DataMember] public string Name { get; set; }
        protected BinaryNode<T> left;
        protected BinaryNode<T> right;
        [JsonIgnore] public bool IsRight { get => Direction == NodeDirection.Right; }
        [JsonIgnore] public bool IsLeft { get => Direction == NodeDirection.Left; }
        [DataMember]
        public virtual BinaryNode<T> Left
        {
            get => left;
            set
            {
                left = value;
                if (value != null)
                {
                    left.Name = this.Name + ".Left";
                    left.Direction = NodeDirection.Left;
                    left.Parent = this;
                }
            }
        }
        [DataMember]
        public virtual BinaryNode<T> Right
        {
            get => right;
            set
            {
                right = value;
                if (value != null)
                {
                    right.Name = this.Name + ".Right";
                    right.Direction = NodeDirection.Right;
                    right.Parent = this;
                }
            }
        }
        public BinaryNode<T> Copy(string name = null)
        {
            var ret = new BinaryNode<T>(data: this.Value, name: name);
            if (string.IsNullOrEmpty(name)) { ret.Name = this.Name; }
            return ret;
        }
        public override IEnumerable<BinaryNode<T>> Children()
        {
            if (Left != null) { yield return Left; }
            if (Right != null) { yield return Right; }
        }
        public override string ToString() => Name + " " + Value;
        public IEnumerable<BinaryNode<T>> InOrder()
        {
            if (Left != null)
            {
                foreach (var item in Left.InOrder()) { yield return item; }
            }
            yield return this;
            if (Right != null)
            {
                foreach (var item in Right.InOrder()) { yield return item; }
            }
        }
        public IEnumerable<BinaryNode<T>> OutOrder()
        {
            if (Right != null)
            {
                foreach (var item in Right.OutOrder()) { yield return item; }
            }
            yield return this;
            if (Left != null)
            {
                foreach (var item in Left.OutOrder()) { yield return item; }
            }
        }

        public BinaryNode<T> clone() => new BinaryNode<T>(data: this.Value, name: this.Name);
        public bool Equals(BinaryNode<T> other)
        {
            if (other is null) { return false; }
            if (object.ReferenceEquals(this, other)) { return true; }

            bool sameName = this.Name.Equals(other.Name);
            bool sameData = this.Value.Equals(other.Value);
            bool sameChildren = true;

            if (this.Left != null || other.Left != null) { sameChildren &= this.Left != null && this.Left.Equals(other.Left); }
            if (this.Right != null || other.Right != null) { sameChildren &= this.Right != null && this.Right.Equals(other.Right); }

            return sameName && sameData && sameChildren;
        }
        public string Print(Func<BinaryNode<T>, object> textFunc = null) => PrintInternal(textFunc, string.Empty, false, false);
        private string PrintInternal(Func<BinaryNode<T>, object> textFunc, string indent, bool last, bool isChild)
        {
            if (textFunc is null) { textFunc = n => n; }
            var ret = new StringBuilder();
            ret.Append(indent);
            if (last)
            {
                ret.Append("└─");
                indent += "  ";
            }
            else if (isChild)
            {
                ret.Append("├─");
                indent += "│ ";
            }
            ret.AppendLine(textFunc(this).ToString());
            var hasChildren = Children().Count() > 0;
            if (hasChildren)
            {
                ret.Append(Left?.PrintInternal(textFunc, indent, false, true) ?? indent + "├\n");
                ret.Append(Right?.PrintInternal(textFunc, indent, true, true) ?? indent + "└\n");
            }
            return ret.ToString();
        }
        public override bool Equals(object obj) => (obj.GetType() == this.GetType()) ? this.Equals(obj as BinaryNode<T>) : base.Equals(obj);
        public override int GetHashCode() => Print().GetHashCode();
    }
}