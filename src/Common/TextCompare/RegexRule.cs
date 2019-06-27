using System;

namespace Common.TextCompare
{
    public class RegexRule
    {
        public enum Type
        {
            Unknown, Wildcard, Character
        }
        private char character;
        private bool zeroOrMore;
        public bool ZeroOrMore { get => zeroOrMore; set => zeroOrMore = value; }
        public char Character { get => character; set => character = value; }
        public RegexRule(char character, bool zeroOrMore = false)
        {
            Character = character;
            ZeroOrMore = zeroOrMore;
        }
        public override string ToString()
        {
            var ret = "Rule: ";
            ret += Character;
            if (ZeroOrMore) ret += "*";
            return ret;
        }
        public bool Test(string text)
        {
            var ret = true;
            if (ZeroOrMore)
            {
                int i = 0;
                while (ret && i < text.Length)
                {
                    var testChar = text[i];
                    ret &= Character == '.' || Character == testChar;
                    i++;
                }
            }
            else if (text.Length != 1) { ret = false; }
            else { ret &= Character == '.' || Character == text[0]; }
            return ret;
        }
    }
}