using System.Collections.Generic;
using System.Linq;
using Common.Regex;

namespace Common
{
    public class Solution25
    {
        public static bool Regex(string input, string test)
        {
            var ret = false;
            System.Diagnostics.Debug.WriteLine(input);
            System.Diagnostics.Debug.WriteLine(test);
            if (IsCorrectCharacterCount(input, test))
            {
                var matches = new Dictionary<RegexRule, List<(int, int)>>();
                var rules = GenerateRulesFromTest(test);
                var firstChar = 0;
                var ruleIndex = 0;
                var RuleMatchFound = true;
                while (RuleMatchFound && ruleIndex < rules.Count)
                {
                    var rule = rules[ruleIndex];
                    System.Diagnostics.Debug.WriteLine(rule);
                    RuleMatchFound = TryMatchRules(input, firstChar, rule, out var matchList);
                    if (!rule.ZeroOrMore) { firstChar++; RuleMatchFound = true; }
                    ruleIndex++;
                }
            }
            else { System.Diagnostics.Debug.WriteLine("wrong chara count"); }
            return ret;
        }
        private static bool TryMatchRules(string input, int firstChar, RegexRule rule, out List<(int, int)> matchList)
        {
            var ret = false;
            matchList = new List<(int, int)>();
            foreach (var substring in SubstringsFromPosition(input, firstChar, rule.ZeroOrMore))
            {
                System.Diagnostics.Debug.WriteLine($"checking '{substring.Item1}'");
                if (rule.Test(substring.Item1)) { matchList.Add(substring.Item2); }
            }
            return ret;
        }
        private static IEnumerable<(string, (int, int))> SubstringsFromPosition(string input, int firstChar, bool zeroOrMore)
        {
            for (int startCharIndex = firstChar; startCharIndex < input.Length; startCharIndex++)
            {
                int subStringCount;
                var x = 0;
                if (zeroOrMore) { subStringCount = input.Length - startCharIndex; } else { subStringCount = 0; x++; }
                for (int charCount = x; charCount <= subStringCount; charCount++)
                {
                    yield return (input.Substring(startCharIndex, charCount), (startCharIndex, charCount));
                }
            }
        }
        private static bool IsCorrectCharacterCount(string input, string test)
        {
            int zeroOrMoreRuleCount = test.Where(e => e == '*').Count();
            int mandatoryRuleCount = test.Where(e => e != '*').Count() - zeroOrMoreRuleCount;
            bool hasZeroOrMoreTypeRule = zeroOrMoreRuleCount != 0;
            bool notTooManyCharacters = input.Length <= test.Length;
            bool enoughCharacters = mandatoryRuleCount <= input.Length;
            if (hasZeroOrMoreTypeRule) { notTooManyCharacters = true; }
            bool v = enoughCharacters && notTooManyCharacters;
            return v;
        }
        public static List<RegexRule> GenerateRulesFromTest(string test)
        {
            var rules = new List<RegexRule>();
            var zeroOrMore = false;
            for (int i = test.Length - 1; i >= 0; i--)
            {
                var symbolString = test[i].ToString().ToUpper();
                var symbol = symbolString.ToCharArray()[0];
                var parse = false;
                switch (symbol)
                {
                    case '.':
                        parse = true;
                        break;
                    case '*':
                        parse = false;
                        zeroOrMore = true;
                        break;
                    default:
                        parse = false;
                        break;
                }
                if (symbol >= 'A' && symbol <= 'Z') { parse = true; }
                if (parse) { rules.Insert(0, new RegexRule(symbol, zeroOrMore)); zeroOrMore = false; }
            }
            return rules;
        }
    }
}