using System;

namespace Common.Sets
{
    public interface IElement<T> where T : IEquatable<T>
    {
        bool IsSame(IElement<T> other);
    }
}