using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Url
{
    public class Shortener
    {
        private Random rand;
        private Dictionary<string, string> dict = new Dictionary<string, string>();
        public Shortener(int seed = 0)
        {
            if (seed == 0) { rand = new Random(); }
            else { rand = new Random(seed); }
            dict.Add(default(string), string.Empty);
        }
        public string Shorten(string url)
        {
            var encoded = dict.Where(u => u.Value == url).FirstOrDefault().Key;
            if (string.IsNullOrWhiteSpace(encoded))
            {
                int v = url.GetHashCode();
                do
                {
                    encoded = v.ToString("X4");
                    v++;
                } while (dict.ContainsValue(encoded));
            }
            dict.Add(url, encoded);
            return encoded;
        }
        public string Restore(string url)
        {
            throw new NotImplementedException();
        }
    }
}