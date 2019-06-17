using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Solution28
    {
        public class PaddedWord
        {
            public PaddedWord(string word, char joiner, int spaces)
            {
                Word = word;
                Joiner = joiner;
                Spaces = spaces;
            }

            public string Word { get; set; }
            public char Joiner { get; set; }
            public int Spaces { get; set; }
            public int Length { get => Word.Length + Spaces; }
            public override string ToString() => Word + new String(Joiner, Spaces);
        }
        public static bool TryPeek<T>(this Queue<T> queue, out T peek)
        {
            var ret = false;
            peek = default(T);
            try
            {
                peek = queue.Peek();
                ret = true;
            }
            catch { }
            return ret;
        }
        public static string[] Justify(string[] input, int lineLength)
        {
            var ret = new List<string>();
            var lengths = input.Select(w => w.Length);
            var q = new Queue<string>(input);
            do
            {
                var line = new List<string>();
                do
                {
                    line.Add(q.Dequeue());
                } while (q.TryPeek(out var nextWord) && line.Select(w => w.Length).Sum() + nextWord.Length + 1 < lineLength);
                ret.Add(
                    line.JustifyJoin(' ', lineLength));
            } while (q.Count > 0);
            return ret.ToArray();
        }
        public static string JustifyJoin(this IEnumerable<string> line, char joiner, int lineLength)
        {
            var wordList = new List<PaddedWord>();
            foreach (var word in line)
            {
                var paddedWord = new PaddedWord(word, joiner, 0);
                wordList.Add(paddedWord);
            }
            for (int i = 0; wordList.Select(w => w.Length).Sum() < lineLength; i++)
            {
                int index = i % Math.Max(1, (wordList.Count - 1));
                var x = wordList[index];
                x.Spaces++;
            }
            return string.Join(null, wordList);
        }
    }
}