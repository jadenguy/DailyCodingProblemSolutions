using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Solution134
    {
        public class SparseArray<T>
        {
            public SparseArray(T[] array)
            {
                Size = array.Length;
                for (int i = 0; i < Size; i++)
                {
                    Set(i, array[i]);
                }
            }
            private Dictionary<int, T> realValues { get; } = new Dictionary<int, T>();
            public int Size { get; }
            public int StorageSize { get => realValues.Count(); }
            public void Set(int index, T value)
            {
                if (value.Equals(default(T))) { realValues.Remove(index); }
                else { realValues[index] = value; }
            }
            public T Get(int v)
            {
                realValues.TryGetValue(v, out var r);
                return r;
            }
        }
    }
}