using System.Collections.Generic;

namespace Common
{
    public class Solution139
    {
        public class PeekableIterator<T> : IIterator<T>
        {
            private Iterator<T> innerIterator;
            private T peekNext;
            public bool HasNext => innerIterator.HasNext;
            public PeekableIterator(Iterator<T> iterator)
            {
                this.innerIterator = iterator ?? throw new System.ArgumentNullException(nameof(iterator));
                Next();
            }
            public T Next()
            {
                var ret = peekNext;
                peekNext = HasNext ? innerIterator.Next() : default;
                return ret;
            }
            public T PeekNext() => peekNext;
            public void Reset() => innerIterator.Reset();
        }
        public interface IIterator<T>
        {
            bool HasNext { get; }
            T Next();
            void Reset();
        }
        public class Iterator<T> : IIterator<T>
        {
            private  IEnumerator<T> enumerator;
            private readonly IEnumerable<T> innerEnumerable;
            private bool hasNext;
            public bool HasNext { get => hasNext; }
            public Iterator(IEnumerable<T> enumerable)
            {
                innerEnumerable = enumerable ?? throw new System.ArgumentNullException(nameof(enumerable));
                enumerator = innerEnumerable.GetEnumerator();
                Next();
                Reset();
            }
            public T Next()
            {
                hasNext = enumerator.MoveNext();
                return hasNext ? enumerator.Current : default;
            }
            public void Reset() => enumerator = innerEnumerable.GetEnumerator();
        }
    }
}