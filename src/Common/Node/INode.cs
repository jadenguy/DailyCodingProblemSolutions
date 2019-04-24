using System.Collections.Generic;

namespace Common.Node
{
    public interface INode<T> where T : INode<T>
    {
        IEnumerable<T> Children();
    }
}