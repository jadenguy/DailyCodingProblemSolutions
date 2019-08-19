using System;
using System.Collections.Generic;

namespace Common.Test
{
    public class Solution057
    {
        public static IEnumerable<string> TextToLines(string text, int k)
        {
            var ret = string.Empty;
            if (string.IsNullOrWhiteSpace(text))
            {
                yield return ret;
                yield break;
            }
            else
            {
                var lineStart = 0;
                var lastSpace = 0;
                var lineCursor = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == ' ')
                    {
                        lastSpace = i;
                    }
                    lineCursor++;
                    if (lineCursor > k)
                    {
                        ret = text.Substring(lineStart, lastSpace - lineStart);
                        yield return ret;
                        lineStart = lastSpace + 1;
                        lineCursor = i - lastSpace;
                    }
                }
                ret = text.Substring(lineStart, text.Length - lineStart);
                yield return ret;
            }
        }
    }
}