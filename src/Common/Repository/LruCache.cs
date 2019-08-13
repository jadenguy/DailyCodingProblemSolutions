using System;

namespace Common
{
    public class LruCache<TKey, TValue>
        where TKey : IEquatable<TKey>
    {
        private TValue[] values;
        private TKey[] keys;
        private int writeHead = 0;
        public int Capacity { get => keys.Length; }
        public int WriteHead { get => writeHead % Capacity; }
        public LruCache(int capacity)
        {
            keys = new TKey[capacity];
            values = new TValue[capacity];
        }
        public void Set(TKey key, TValue value)
        {
            if (TryGetIndex(key, out var index))
            {
                values[index] = value;
                if (key.Equals(default(TKey)))
                {
                    writeHead++;
                }
            }
            else
            {
                keys[WriteHead] = key;
                values[WriteHead] = value;
                writeHead++;
            }
        }
        public TValue this[TKey key] { get => Get(key); }
        public TValue Get(TKey key)
        {
            bool x = TryGetIndex(key, out var index);
            if (x) { return values[index]; }
            else { return default(TValue); }
        }
        private bool TryGetIndex(TKey key, out int index)
        {
            var ret = false;
            index = -1;
            for (int i = 0; !ret && i < writeHead && i < Capacity; i++)
            {
                TKey testKey = keys[i];
                if (testKey != null && testKey.Equals(key))
                {
                    index = i;
                    ret = true;
                }
            }
            return ret;
        }
    }
}