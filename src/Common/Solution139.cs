using System.Collections.Generic;

namespace Common
{
    public class Solution139
    {
        public class Iterator<T>
        {
            private readonly IEnumerator<T> enumerator;
            private IEnumerable<T> innerEnumerable;
            private bool hasNext;
            public bool HasNext { get => hasNext; }
            public Iterator(IEnumerable<T> enumerable)
            {
                innerEnumerable = enumerable;
                enumerator = innerEnumerable.GetEnumerator();
            }
            public T Next()
            {
                var ret = enumerator.Current;
                hasNext = enumerator.MoveNext();
                return ret;
            }
            public void Reset() => enumerator.Reset();
        }
    }
}