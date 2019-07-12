using System;
using Common.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution34
    {
        enum Direction
        {
            Left = 0, Right = 1
        }
        public static string Palindromize(string input)
        {
            // return PalindromizeOld(input);
            var substrings = AllSubStrings(input);
            var masks = substrings.Select(t => new { From = t.from, Text = t.text, Mask = PalindromeMask(t.text) }).ToArray();
            var mostMaskCharacters = masks.OrderBy(k => k.Mask.Length).OrderByDescending(k => k.Mask.Where(b => b).Count());
            foreach (var substring in mostMaskCharacters)
            {
                System.Diagnostics.Debug.WriteLine("");
                System.Diagnostics.Debug.WriteLine(substring.From);
                System.Diagnostics.Debug.WriteLine(string.Join('\t', substring.Text.ToCharArray()));
                System.Diagnostics.Debug.WriteLine(string.Join('\t', substring.Mask));
            }
            return input;
        }
        private static bool[] PalindromeMask(string input)
        {
            var ret = new bool[input.Length];
            var i = 0;
            while (i <= input.Length / 2)
            {
                int leftIndex = i;
                int rightIndex = input.Length - 1 - i;
                char leftChar = input[leftIndex];
                char rightChar = input[rightIndex];
                if (leftChar == rightChar)
                {
                    ret[leftIndex] = true;
                    ret[rightIndex] = true;
                }
                i++;
            }

            return ret;
        }

        private static IEnumerable<(string text, int from)> AllSubStrings(string input)
        {
            for (int a = 0; a < input.Length; a++)
            {
                for (int b = 1; b <= input.Length - a; b++)
                {
                    yield return (input.Substring(a, b), a);
                }
            }
        }

        public static string PalindromizeOld(string input)
        {
            var i = 0;
            while (i <= input.Length / 2)
            {
                int leftIndex = i;
                int rightIndex = input.Length - 1 - i;
                char leftChar = input[leftIndex];
                char rightChar = input[rightIndex];
                int comparison = Math.Sign(leftChar.CompareTo(rightChar));
                char insertChar = leftChar;
                int insertIndex = rightIndex;
                Direction insertDirection = Direction.Right;
                if (comparison != 0)
                {
                    if (comparison == 1)
                    {
                        insertChar = rightChar;
                        insertIndex = leftIndex;
                        insertDirection = Direction.Left;
                    }
                    input = addLetterIn(input, insertChar, insertIndex, insertDirection);
                }
                i++;
            }
            return input;
        }
        [System.Diagnostics.DebuggerStepThrough]
        private static Direction PickDirection(int comparison)
        {
            Direction direction;
            switch (comparison)
            {
                case 1:
                    direction = Solution34.Direction.Right;
                    break;
                default:
                    direction = Solution34.Direction.Left;
                    break;
            }
            return direction;
        }
        private static string addLetterIn(string input, char letter, int place, Direction direction)
        {
            input = input.Insert(place + (int)direction, letter.ToString());
            return input;
        }
    }
}