using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Solution134
    {
        public class SparseArray<T> : IEnumerable<T>
        {
            public const string SparseArrayExceptionMessage = "SparseArrayException";
            private Dictionary<int, T> realValues { get; } = new Dictionary<int, T>();
            public int Length { get; }
            public int StorageSize { get => realValues.Count(); }
            public SparseArray(T[] array)
            {
                Length = array.Length;
                for (int i = 0; i < Length; i++)
                {
                    Set(i, array[i]);
                }
            }
            public SparseArray(T[] array, int length) : this(array)
            {
                Length = length;
                realValues.Keys.Where(k => k >= length).Select(k => realValues.Remove(k));
            }
            public SparseArray(int length) => this.Length = length;
            public IEnumerable<(int Key, T Value)> GetValues() => realValues.OrderBy(n => n.Key).Select(x => (x.Key, x.Value));
            public T this[int i] { get => Get(i); set => Set(i, value); }
            public void Set(int index, T value)
            {
                ValidateIndex(index);
                if (value.Equals(default(T))) { realValues.Remove(index); }
                else { realValues[index] = value; }
            }
            public T Get(int index)
            {
                ValidateIndex(index);
                realValues.TryGetValue(index, out var r);
                return r;
            }
            private void ValidateIndex(int index) { if (index >= Length || index < 0) { throw new System.IndexOutOfRangeException(SparseArrayExceptionMessage); } }
            public IEnumerator<T> GetEnumerator() => Enumerable.Range(0, Length).Select(i => Get(i)).GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }
    }
}