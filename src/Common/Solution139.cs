using System.Collections.Generic;

namespace Common
{
    public class Solution139
    {
        public class PeekableIterator<T> : IIterator<T>
        {
            private Iterator<T> iterator;
            private T peekNext;
            private readonly bool isPeek;            public bool HasNext => iterator.HasNext;
            public PeekableIterator(Iterator<T> iterator)
            {
                this.iterator = iterator ?? throw new System.ArgumentNullException(nameof(iterator));
                peekNext = iterator.Next();
            }
            public T Next()
            {
                var ret = peekNext;
                peekNext = iterator.Next();
                return ret;
            }
            public T PeekNext() => peekNext;
            public void Reset() => iterator.Reset();
        }        public interface IIterator<T>
        {
            bool HasNext { get; }
            T Next();
            void Reset();
        }
        public class Iterator<T> : IIterator<T>
        {
            private readonly IEnumerator<T> enumerator;
            private IEnumerable<T> innerEnumerable;
            private bool hasNext;
            public bool HasNext { get => hasNext; }
            public Iterator(IEnumerable<T> enumerable)
            {
                innerEnumerable = enumerable ?? throw new System.ArgumentNullException(nameof(enumerable));
                enumerator = innerEnumerable.GetEnumerator();
            }
            public T Next()
            {
                hasNext = enumerator.MoveNext();
                return enumerator.Current;
            }
            public void Reset() => enumerator.Reset();
        }
    }
}