using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class Solution027

    {
        public static bool Validate(this string input)
        {
            var ret = true;
            var stack = new Stack<char>();
            var dict = new Dictionary<char, char>
            {
                { ']', '[' },
                { '}', '{' },
                { ')', '(' }
            };
            var traveler = input.GetEnumerator();
            while (ret && traveler.MoveNext())
            {
                var letter = traveler.Current;
                bool open = dict.Values.Any(e => e == letter);
                if (open)
                {
                    stack.Push(letter);
                }
                else
                {
                    var closes = dict[letter] == stack.Peek();
                    if (closes) { stack.Pop(); }
                    else { ret = false; }
                }
            }
            ret &= stack.Count == 0;
            return ret;
        }
    }
}