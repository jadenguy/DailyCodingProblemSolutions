using System;
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
            int zeroOrMoreRuleCount = input.Where(e => e == '*').Count();
            int mandatoryRuleCount = input.Where(e => e != '*').Count() - zeroOrMoreRuleCount;
            bool hasZeroOrMoreTypeRule = zeroOrMoreRuleCount == 0;
            bool notTooManyCharacters = input.Length == test.Length;
            if (hasZeroOrMoreTypeRule)
            {
                bool enoughCharacters = mandatoryRuleCount <= input.Length;
                notTooManyCharacters = input.Length <= test.Length;
            }
            {
                var matches = new Dictionary<RegexRule, List<(int, int)>>();
                var rules = generateRulesFromTest(test);
                for (int i = 0; i < rules.Count; i++)
                {
                    var rule = rules[i];
                    for (int j = 0; j < input.Length; j++)
                    {

                    }
                }
            }
            return ret;
        }
        private static List<RegexRule> generateRulesFromTest(string test)
        {
            var rules = new List<RegexRule>();
            var zeroOrMore = false;
            for (int i = test.Length - 1; i >= 0; i--)
            {
                var symbolString = test[i].ToString().ToUpper();
                var symbol = symbolString.ToCharArray()[0];
                var parse = false;
                var type = RegexRule.Type.Unknown;
                switch (symbol)
                {
                    case '.':
                        parse = true;
                        type = RegexRule.Type.Wildcard;
                        break;
                    case '*':
                        parse = false;
                        zeroOrMore = true;
                        break;
                    default:
                        parse = false;
                        break;
                }
                if (symbol >= 'A' && symbol <= 'Z') { parse = true; type = RegexRule.Type.Character; }
                if (parse) { rules.Insert(0, new RegexRule(symbol, type, zeroOrMore)); zeroOrMore = false; }
            }
            return rules;
        }
    }
}