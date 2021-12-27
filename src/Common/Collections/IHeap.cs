using System.Collections;
using System.Collections.Generic;

namespace Common.Collections
{
    public abstract class IHeap<T> : IEnumerable<T>
    {
        public enum HeapMinMax { Min = -1, Max = 1 }
        public HeapMinMax Style { get; }
        protected IHeap(HeapMinMax style) => Style = style;
        internal abstract T Pop();
        internal abstract void Push(T element);

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}