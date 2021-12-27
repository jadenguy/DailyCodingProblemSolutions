using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Collections
{

    public class FakeHeap<T> : IHeap<T> where T : IComparable<T>
    {

        private List<T> internalHeap = new List<T>();

        public FakeHeap(HeapMinMax style) : base(style)
        {
        }

        public override IEnumerator<T> GetEnumerator() => internalHeap.GetEnumerator();

        internal override T Pop()
        {
            var ret = internalHeap[internalHeap.Count];
            internalHeap.RemoveAt(internalHeap.Count);
            return ret;
        }

        internal override void Push(T element)
        {
            internalHeap.Add(element);
            internalHeap = (Style == HeapMinMax.Max ? internalHeap.OrderByDescending(n => n) : internalHeap.OrderBy(n => n)).ToList();
        }
    }

}