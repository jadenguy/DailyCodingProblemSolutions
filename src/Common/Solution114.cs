using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public class Solution114
    {
        public static string ReverseWordOrderDelimiterList(string input, string delimiterSet)
        {
            var phrases = SeparatePhrases(input, delimiterSet, out var startDelimited);
            SeparateWordsReverseAndDelimiters(phrases, startDelimited, out var wordsReverse, out var delimiters);
            var ret = ZipWordsReverseAndDelimiters(startDelimited, wordsReverse, delimiters);
            return ret.Print("");
        }
        private static List<string> ZipWordsReverseAndDelimiters(bool startsDelimited, Stack<string> wordsReverse, Queue<string> delimiters)
        {
            var ret = new List<string>();
            if (startsDelimited) { ret.Add(delimiters.Dequeue()); }
            while (wordsReverse.Count > 0)
            {
                string word = wordsReverse.Pop();
                ret.Add(word);
                try
                {
                    string del = delimiters.Dequeue();
                    ret.Add(del);
                }
                catch (System.Exception) { }
            }

            return ret;
        }
        private static void SeparateWordsReverseAndDelimiters(IEnumerable<string> phrases, bool startsDelimited, out Stack<string> wordsReverse, out Queue<string> delimiters)
        {
            wordsReverse = new Stack<string>();
            delimiters = new Queue<string>();
            var isDelimiter = startsDelimited;
            foreach (var word in phrases)
            {
                if (isDelimiter) { delimiters.Enqueue(word); }
                else { wordsReverse.Push(word); }
                isDelimiter = !isDelimiter;
            }
        }
        private static IEnumerable<string> SeparatePhrases(string input, string delimiters, out bool startDelimited)
        {
            var length = input.Length;
            var ret = new Queue<string>();
            var current = input.FirstOrDefault();
            var wasDelimiter = delimiters.Contains(current);
            startDelimited = wasDelimiter;
            var words = new Queue<string>();
            var wordStart = 0;
            for (int i = 1; i < length; i++)
            {
                current = input[i];
                var isDelimiter = delimiters.Contains(current);
                var wasSeries = isDelimiter ^ wasDelimiter;
                if (wasSeries)
                {
                    var word = input.Substring(wordStart, i - wordStart);
                    words.Enqueue(word);
                    wordStart = i;
                }
                wasDelimiter = isDelimiter;
            }
            words.Enqueue(input.Substring(wordStart, length - wordStart));
            return words;
        }
    }
}