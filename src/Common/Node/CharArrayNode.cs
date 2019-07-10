using System;
using System.Collections;
using System.Collections.Generic;

namespace Common.Node
{
    public class CharArrayNode : Node<CharArrayNode>, IDictionary<char, CharArrayNode>, IEquatable<CharArrayNode>
    {
        public string Word { get; set; }
        public bool WordEndsHere { get; set; }
        public CharArrayNode(char? letter, string wordUntilNow)
        {
            this.Letter = letter;
            this.Word = wordUntilNow + letter.ToString();
        }
        private Dictionary<char, CharArrayNode> nextLetter { get; set; } = new Dictionary<char, CharArrayNode>();
        public char? Letter { get; set; }
        public ICollection<char> Keys => ((IDictionary<char, CharArrayNode>)nextLetter).Keys;
        public ICollection<CharArrayNode> Values => ((IDictionary<char, CharArrayNode>)nextLetter).Values;
        public int Count => ((IDictionary<char, CharArrayNode>)nextLetter).Count;
        public bool IsReadOnly => ((IDictionary<char, CharArrayNode>)nextLetter).IsReadOnly;
        public CharArrayNode this[char key] { get => ((IDictionary<char, CharArrayNode>)nextLetter)[key]; set => ((IDictionary<char, CharArrayNode>)nextLetter)[key] = value; }
        public void Add(char key, CharArrayNode value) => ((IDictionary<char, CharArrayNode>)nextLetter).Add(key, value);
        public bool ContainsKey(char key) => ((IDictionary<char, CharArrayNode>)nextLetter).ContainsKey(key);
        public bool Remove(char key) => ((IDictionary<char, CharArrayNode>)nextLetter).Remove(key);
        public bool TryGetValue(char key, out CharArrayNode value) => ((IDictionary<char, CharArrayNode>)nextLetter).TryGetValue(key, out value);
        public void Add(KeyValuePair<char, CharArrayNode> item) => ((IDictionary<char, CharArrayNode>)nextLetter).Add(item);
        public void Clear() => ((IDictionary<char, CharArrayNode>)nextLetter).Clear();
        public bool Contains(KeyValuePair<char, CharArrayNode> item) => ((IDictionary<char, CharArrayNode>)nextLetter).Contains(item);
        public void CopyTo(KeyValuePair<char, CharArrayNode>[] array, int arrayIndex) => ((IDictionary<char, CharArrayNode>)nextLetter).CopyTo(array, arrayIndex);
        public bool Remove(KeyValuePair<char, CharArrayNode> item) => ((IDictionary<char, CharArrayNode>)nextLetter).Remove(item);
        public IEnumerator<KeyValuePair<char, CharArrayNode>> GetEnumerator() => ((IDictionary<char, CharArrayNode>)nextLetter).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IDictionary<char, CharArrayNode>)nextLetter).GetEnumerator();
        public override string ToString()
        {
            var ret = string.Empty;
            if (Letter != null) { ret = $"{Word} {WordEndsHere} {nextLetter.Count}"; }
            else { ret = $"this is the root {nextLetter.Count}"; }
            return ret;
        }
        public void AddNextLetter(char character)
        {
            if (!ContainsKey(character)) { Add(character, new CharArrayNode(character, Word)); }
        }
        public override IEnumerable<CharArrayNode> Children()
        {
            foreach (var item in this.Values) { yield return item; }
        }

        public bool Equals(CharArrayNode other) => false;
    }
}