using System;
using System.Collections.Generic;

namespace Common.Test
{
    public class Solution057
    {
        public static IEnumerable<string> TextToLines(string text, int k)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                yield return string.Empty;

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
                        yield return text.Substring(lineStart, lastSpace - lineStart); ;
                        lineStart = lastSpace + 1;
                        lineCursor = i - lastSpace;
                    }
                }
                yield return text.Substring(lineStart, text.Length - lineStart);
            }
        }
    }
}