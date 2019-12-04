using System;
using System.Collections;
using System.Collections.Generic;

namespace Common.TextCompare
{
    public class SubString : IEnumerable<SubString>, IComparable<SubString>, IEquatable<SubString>
    {
        public SubString()
        {
        }
        public SubString(string text, int start, int length)
        {
            this.Text = text;
            this.StartCharacter = start;
            this.Length = length;
        }
        public string Text { get; set; }
        public int StartCharacter { get; set; }
        public int Length { get; set; }
        public string Print() => $"{Text} at {StartCharacter} to {StartCharacter + Length - 1}";
        public static implicit operator string(SubString r) => r.Text;
        public override string ToString() => Print();
        private IEnumerable<SubString> ThisEnumerable() => new SubString[] { this };
        public IEnumerator<SubString> GetEnumerator() => ThisEnumerable().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ThisEnumerable().GetEnumerator();
        public int CompareTo(SubString y)
        {
            var x = this;
            if (y is null) { return -1; }
            else
            {
                var text = x.Text.CompareTo(y.Text);
                var start = x.StartCharacter.CompareTo(y.StartCharacter);
                var length = x.Length.CompareTo(y.Length);
                if (text == 0)
                {
                    if (start == 0) { { return length; } }
                    else { return start; }
                }
                else { return text; }
            }
        }
        public bool Equals(SubString other)
        {
            return this.CompareTo(other) == 0;
        }
        public override int GetHashCode()
        {
            return this.Print().GetHashCode();
        }
    }
}