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
    }
}