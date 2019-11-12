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
                var x = header * 7 + 7;
                var ret = this.text.Substring(header * 7, 7);
                header++;
                return ret;
            }
            public void Reset()
            {
                header = 0;
            }
        }
        public static string ReadN(File file, int n)
        {
            var ret = string.Empty;
            for (int i = 0; i <= n / 7; i++)
            {
                ret += file.Read7();
            }
            return ret.Substring(0, n);
        }
    }
}