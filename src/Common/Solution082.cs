using System;

namespace Common
{
    public class Solution082
    {
        public class File
        {
            private string text;
            private int header;
            public File(string text)
            {
                this.text = text;
                this.header = 0;
            }
            public string Read7()
            {
                const int SEVEN = 7;
                int startIndex = header * SEVEN;
                System.Diagnostics.Debug.WriteLine(header);
                header++;
                var remaining = Math.Min(text.Length - startIndex, SEVEN);
                if (remaining > 0) { return this.text.Substring(startIndex, remaining); }
                else { return string.Empty; }
            }
            public void Reset()
            {
                header = 0;
            }
            public override string ToString() => $"{text} {text.Length}";
        }
        public static string ReadN(File file, int n)
        {
            var ret = string.Empty;
            for (int i = 0; i < (n / 7d); i++)
            {
                ret += file.Read7();
            }
            if (!string.IsNullOrEmpty(ret)) { return ret.Substring(0, Math.Min(n, ret.Length)); }
            else { return string.Empty; }
        }
    }
}