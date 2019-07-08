using System.Collections.Generic;
using System.Linq;

namespace Common.Node.Graph
{
    public abstract class GraphNode<T> : Node<T> where T : GraphNode<T>
    {
        public IEnumerable<GraphPath<T>> Paths;
        public override IEnumerable<T> Children()
        {
            var children = Paths.Select(p => (T)p.Next);
            return children;
        }
        public new virtual IEnumerable<T> BreadthFirstSearch()
        {
            var list = new Queue<T>() { };
            var everVisited = new List<T>() { };
            list.Enqueue((T)this);
            do
            {
                var current = list.Dequeue();
                if (!everVisited.Contains(current))
                {
                    yield return current;
                    everVisited.Add(current);
                }
                var children = current.Children().ToArray();
                foreach (var child in children)
                {
                    list.Enqueue(child);
                }
            } while (list.Count != 0);
        }
    }
}