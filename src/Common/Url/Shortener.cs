using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Url
{
    public class Shortener
    {
        private Dictionary<string, string> dict = new Dictionary<string, string>();
        public Shortener() { }
        public string Shorten(string url)
        {
            var exists = dict.TryGetValue(url, out var encoded);
            if (!exists)
            {
                encoded = Encode(url);
                dict.Add(url, encoded);
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
                v++;
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