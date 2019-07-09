using System.Collections.Generic;
using System.Linq;

namespace Common.Node.Graph
{
    public abstract class GraphNode<T> : Node<T>
        where T : GraphNode<T>
    {
        public List<GraphPath<T>> Paths;
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
                    foreach (var child in current.Children()) { list.Enqueue(child); }
                }
            } while (list.Count != 0);
        }
        public IEnumerable<T> Traverse() => this.BreadthFirstSearch();
    }
}