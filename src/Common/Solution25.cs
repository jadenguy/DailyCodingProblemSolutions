using System.Collections.Generic;
using System.Linq;
using Common.TextCompare;

namespace Common
{
    public class Solution25
    {
        public static bool Regex(string input, string test)
        {
            var RulesMatchesFound = true;
            if (IsCorrectCharacterCount(input, test))
            {
                var rules = GenerateRulesFromTest(test);
                RulesMatchesFound = TryMatchRules(input, rules, out var matches);
                var current = new RegexMatch[] { new RegexMatch("", 0, 0) };
                RegexMatch[] join = new RegexMatch[0];
                for (int i = 0; RulesMatchesFound && i < rules.Length; i++)
                {
                    var next = matches[rules[i]];
                    join = current // sequence
                    .Join(
                        next // inner sequence
                        , r => r.StartCharacter + r.Length // outer key
                        , n => n.StartCharacter // inner key
                        , (r, n) => n //returned results
                        ).ToArray();
                    if (join.Length == 0) { RulesMatchesFound = false; }
                    else { current = next; }
                }
                int lastMatchedLetters = 0;
                if (join.Length > 0) { lastMatchedLetters = join.Max(e => e.StartCharacter + e.Length); }
                bool allLettersAccountedFor = lastMatchedLetters == input.Length;
                RulesMatchesFound &= allLettersAccountedFor;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("wrong character count");
                RulesMatchesFound = false;
            }
            return RulesMatchesFound;
        }
        private static bool TryMatchRules(string input, RegexRule[] rules, out Dictionary<RegexRule, RegexMatch[]> matches)
        {
            var firstChar = 0;
            var RulesMatchesFound = true;
            matches = new Dictionary<RegexRule, RegexMatch[]>();
            for (int ruleIndex = 0; RulesMatchesFound && ruleIndex < rules.Length; ruleIndex++)
            {
                var rule = rules[ruleIndex];
                // System.Diagnostics.Debug.WriteLine(rule);
                RulesMatchesFound = TryMatchRule(input, firstChar, rule, out var matchList);
                if (!rule.ZeroOrMore) { firstChar++; } else { RulesMatchesFound = true; }
                matches.Add(rule, matchList);
                // if (RulesMatchesFound) { System.Diagnostics.Debug.WriteLine("This rule has results"); }
            }
            return RulesMatchesFound;
        }

        private static bool TryMatchRule(string input, int firstChar, RegexRule rule, out RegexMatch[] matchList)
        {
            var ret = false;
            matchList = MatchesFromPosition(input, firstChar, rule).ToArray();
            if (matchList.Length > 0) { ret = true; }
            return ret;
        }
        private static IEnumerable<RegexMatch> MatchesFromPosition(string input, int firstChar, RegexRule rule)
        {
            if (input.Length == firstChar) { yield return new RegexMatch("", firstChar, 0, rule); }
            for (int startCharIndex = firstChar; startCharIndex < input.Length; startCharIndex++)
            {
                if (rule.ZeroOrMore)
                {

                    for (int charCount = 0; charCount <= input.Length - startCharIndex; charCount++)
                    {
                        var possibleMatch = new RegexMatch(input.Substring(startCharIndex, charCount), startCharIndex, charCount, rule);
                        // System.Diagnostics.Debug.WriteLine($"Checking {possibleMatch}");
                        if (possibleMatch.Validate()) { yield return possibleMatch; }
                    }
                }
                else
                {
                    var possibleMatch = new RegexMatch(input.Substring(startCharIndex, 1), startCharIndex, 1, rule);
                    // System.Diagnostics.Debug.WriteLine($"Checking {possibleMatch}");
                    if (possibleMatch.Validate()) { yield return possibleMatch; }
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
        public static RegexRule[] GenerateRulesFromTest(string test)
        {
            var rules = new List<RegexRule>();
            var zeroOrMore = false;
            for (int i = test.Length - 1; i >= 0; i--)
            {
                var symbolString = test[i].ToString();
                var symbol = symbolString.ToCharArray()[0];
                var parse = false;
                if (symbol == '*')
                {
                    zeroOrMore = true;
                }
                else { parse = true; }
                if (parse) { rules.Insert(0, new RegexRule(symbol, zeroOrMore)); zeroOrMore = false; }
            }
            return rules.ToArray();
        }
    }
}