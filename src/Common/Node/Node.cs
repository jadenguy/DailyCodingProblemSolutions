using System.Collections.Generic;

namespace Common.Node
{
    public abstract class Node<T> where T : Node<T>
    {
        public virtual IEnumerable<T> BreadthFirstSearch(bool root = true)
        {
            if (root)
            { yield return (T)this; }
            foreach (var child in Children())
            {
                yield return child;
                foreach (var subchild in child.BreadthFirstSearch(false))
                { yield return subchild; }
            }
        }
        public abstract IEnumerable<T> Children();
        public virtual IEnumerable<T> DepthFirstSearch(bool root = true)
        {
            if (root)
            { yield return (T)this; }
            foreach (var child in Children())
            {
                yield return child;
            }
            foreach (var child in Children())
            {
                foreach (var subchild in child.DepthFirstSearch(false))
                { yield return subchild; }
            }
        }
    }
}