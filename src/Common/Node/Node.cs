using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Node
{
    public abstract class Node<T> where T : Node<T>
    {
        public abstract IEnumerable<T> Children();
        public virtual IEnumerable<T> BreadthFirstSearch()
        {
            var list = new Queue<T>() { };
            list.Enqueue((T)this);
            do
            {
                var current = list.Dequeue();
                yield return current;
                var children = current.Children().ToArray();
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
                var children = current.Children().ToArray().Reverse();
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
    }
}