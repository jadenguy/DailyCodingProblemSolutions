using System;

namespace Common.Regex
{
    public class RegexRule
    {
        public enum Type
        {
            Unknown, Wildcard, Character
        }
        private Type ruleType;
        private char character;
        private bool zeroOrMore;
        private Type RuleType { get => ruleType; set => ruleType = value; }
        public bool ZeroOrMore { get => zeroOrMore; set => zeroOrMore = value; }
        public char Character { get => character; set => character = value; }

        public RegexRule(char character, Type type = Type.Character, bool zeroOrMore = false)
        {
            Character = character;
            RuleType = type;
            ZeroOrMore = zeroOrMore;
        }
        public override string ToString()
        {
            var ret = "Rule: ";
            ret += Character;
            if (ZeroOrMore) ret += "*";
            return ret;
        }

        public void Test(string text)
        {
            throw new NotImplementedException();
        }
    }
}