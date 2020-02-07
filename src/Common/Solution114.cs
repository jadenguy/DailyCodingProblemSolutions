using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public class Solution114
    {
        public static string ReverseWordOrderDelimiterList(string input, string delimiters)
        {
            int length = input.Length;
            var current = input.FirstOrDefault();
            var wasChar = delimiters.Contains(current);
            var startsChar = wasChar;
            var words = new Queue<string>();
            var wordStart = 0;
            for (int i = 1; i < length; i++)
            {
                current = input[i];
                var isChar = delimiters.Contains(current);
                var wasSeries = isChar ^ wasChar;
                if (wasSeries)
                {
                    var word = input.Substring(wordStart, i - wordStart);
                    words.Enqueue(word);
                    wordStart = i;
                }
                wasChar = isChar;
            }
            words.Enqueue(input.Substring(wordStart, length - wordStart));
            var ret = new List<string>();
            if (!startsChar) { ret.Add(words.Dequeue()); }
            var wordStack = new Stack<string>(words);
            int count = words.Count;
            for (int i = 0; i < count; i++)
            {
                bool isEven = i % 2 == 0;
                var top = words.Dequeue();
                var bottom = wordStack.Pop();
                ret.Add(isEven ? top : bottom);
            }
            return ret.Print("");
        }
    }
}