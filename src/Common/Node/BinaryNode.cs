﻿using System.Collections;
using System.Collections.Generic;

namespace Common.Node
{
    public class BinaryNode : Node<BinaryNode>
    {
        public BinaryNode(string value, BinaryNode left = null, BinaryNode right = null, string name = "Root")
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
            this.Name = name;
        }
        public string Value { get; set; }
        public string Name { get; set; }
        private BinaryNode left;
        private BinaryNode right;
        public virtual BinaryNode Left
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
        public virtual BinaryNode Right
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
        public override IEnumerable<BinaryNode> Children()
        {
            if (Left != null) { yield return Left; }
            if (Right != null) { yield return Right; }
        }
        public override string ToString() => Name + " " + Value;
        public IEnumerable<BinaryNode> InOrder()
        {
            if (left != null)
            {
                foreach (var item in left.InOrder())
                {
                    yield return item;
                }
            }
            yield return this;
            if (right != null)
            {
                foreach (var item in right.InOrder())
                {
                    yield return item;
                }
            }
        }  public IEnumerable<BinaryNode> OutOrder()
        {
            if (right != null)
            {
                foreach (var item in right.InOrder())
                {
                    yield return item;
                }
            }
            yield return this;
            if (left != null)
            {
                foreach (var item in left.InOrder())
                {
                    yield return item;
                }
            }
        }
    }
}