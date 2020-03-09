using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Extensions
{
    public static class DictionaryExtension
    {
        public static bool TryGetKey<TKey, TValue>(this Dictionary<TKey, TValue> dict, TValue value, out TKey key)
        {
            var enumerable = dict.Where(p => p.Value.Equals(value)).Select(p => p.Key).ToArray();
            key = enumerable.FirstOrDefault();
            return enumerable.Count() == 1;
        }
        public static void UpSert<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, Func<TValue, TValue> func) => dict[key] = func(dict.TryGetValue(key, out var v) ? v : v);
        public static void UpSertRange<TKey, TValue>(this Dictionary<TKey, TValue> dict, IEnumerable<TKey> keys, Func<TValue, TValue> func)
        {
            foreach (var key in keys)
            {
                dict.UpSert(key, func);
            }
        }
    }
}