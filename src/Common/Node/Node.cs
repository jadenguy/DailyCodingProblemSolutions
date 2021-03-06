﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Node
{
    public abstract class Node<T> where T : Node<T>
    {
        public abstract IEnumerable<T> Children();
        public virtual IEnumerable<T> BreadthFirstSearch()
        {
            var list = new Queue<T>() { };
            var check = new HashSet<T>() { };
            list.Enqueue((T)this);
            do
            {
                var current = list.Dequeue();
                if (check.Contains(current)) { throw new System.StackOverflowException("Loop detected."); }
                yield return current;
                check.Add(current);
                var children = current.Children();
                foreach (var child in children)
                {
                    list.Enqueue(child);
                }
            } while (list.Count != 0);
        }
        public virtual IEnumerable<T> PreOrder(bool root = true)
        {
            var list = new Stack<T>() { };
            list.Push((T)this);
            do
            {
                var current = list.Pop();
                yield return current;
                var children = current.Children().Reverse();
                foreach (var child in children)
                {
                    list.Push(child);
                }
            } while (list.Count != 0);
        }
        public virtual IEnumerable<T> PreOrderReverseChildren(bool root = true)
        {
            var list = new Stack<T>() { };
            list.Push((T)this);
            do
            {
                var current = list.Pop();
                yield return current;
                var children = current.Children().ToArray();
                foreach (var child in children)
                {
                    list.Push(child);
                }
            } while (list.Count != 0);
        }
        public virtual IEnumerable<T> PostOrder(bool root = true)
        {
            foreach (var child in Children())
            {
                foreach (var subchild in child.PostOrder(false))
                { yield return subchild; }
                // yield return child;
            }
            // if (root)
            { yield return (T)this; }
        }
        private string PrintInternal(Func<Node<T>, string> textFunc, string indent, bool last, bool isChild)
        {
            if (textFunc is null) { textFunc = n => n.ToString(); }
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
            ret.AppendLine(textFunc(this));
            var children = Children().ToList();

            for (int i = 0; i < children.Count; i++) { ret.Append(children[i].PrintInternal(textFunc, indent, i == children.Count - 1, true)); }
            return ret.ToString();
        }
        public string Print(Func<Node<T>, string> textFunc = null) => PrintInternal(textFunc, string.Empty, false, false);
    }
}