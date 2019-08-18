using System.Collections.Generic;
using System.Linq;

namespace Common.Url
{
    public static class UrlExtension
    {
        public static bool TryGetKey<TKey, TValue>(this Dictionary<TKey, TValue> dict, TValue value, out TKey key)
        {
            var enumerable = dict.Where(p => p.Value.Equals(value)).Select(p => p.Key).ToArray();
            key = enumerable.FirstOrDefault();
            return enumerable.Count() == 1;
        }
    }

    public class Shortener
    {
        private Dictionary<string, string> dict = new Dictionary<string, string>();
        public Shortener() { }
        public string Shorten(string url)
        {
            var exists = dict.TryGetKey(url, out var encoded);
            if (!exists)
            {
                encoded = Encode(url);
                dict.Add(encoded, url);
            }
            return encoded;
        }
        private string Encode(string url)
        {
            string encoded;
            int v = url.GetHashCode();
            do
            {
                encoded = v.ToString("X3").Substring(0, 6);
                v = encoded.GetHashCode();
            } while (dict.ContainsValue(encoded));
            return encoded;
        }
        public string Restore(string url)
        {
            dict.TryGetValue(url, out var value);
            return value;
        }
    }
}