using System;
using Common.Extensions;
using System.Collections.Generic;
using System.Linq;
using Common.TextCompare;

namespace Common
{
    public class Solution034

    {
        // enum Direction
        // {
        //     Left = 0, Right = 1
        // }
        public static string Palindromize(string input)
        {
            if (input.Length < 2) { return input; }
            var ret = string.Empty;
            var left = input.First();
            var right = input.Last();
            string middle = input.Substring(1, input.Length - 2);
            if (left == right) { ret = left + Palindromize(middle) + right; }
            else
            {
                var newLeft = left + Palindromize(middle + right) + left;
                var newRight = right + Palindromize(left + middle) + right;
                var orderedArray = (new string[] { newLeft, newRight }).OrderBy(x => x).OrderBy(x => x.Length).ToArray();
                ret = orderedArray.First();
            }
            return ret;
        }
        // public static string PalindromizeAlsoTrash(string input)
        // {
        //     int length = input.Length;
        //     List<CharMatch> allMatches = MatchAllChar(input, length);
        //     var bestMatches = new Stack<CharMatch>();
        //     var orderedMatchList = allMatches.OrderBy(m => m.Letter).OrderByDescending(m => m.RightTextIndex - m.LeftTextIndex).ToArray();
        //     var current = orderedMatchList.First();
        //     CharMatch next;
        //     do
        //     {
        //         bestMatches.Push(current);
        //         next = orderedMatchList.Where(n => n.LeftTextIndex > current.LeftTextIndex && n.RightTextIndex < current.RightTextIndex).ToArray().FirstOrDefault();
        //         current = next;
        //     } while (next != null);
        //     var ret = string.Empty;
        //     while (bestMatches.Count > 0)
        //     {
        //         next = bestMatches.Pop();
        //         if (next != null && next.LeftTextIndex == next.RightTextIndex)
        //         {
        //             ret += next.Letter;
        //         }
        //     }
        //     return ret;
        // }

        // private static List<CharMatch> MatchAllChar(string input, int length)
        // {
        //     var allMatches = new List<CharMatch>();
        //     for (int leftIndex = 0; leftIndex < length; leftIndex++)
        //     {
        //         char leftChar = input[leftIndex];
        //         for (int rightIndex = leftIndex; rightIndex < length; rightIndex++)
        //         {
        //             char rightChar = input[rightIndex];
        //             if (leftChar == rightChar)
        //             {
        //                 allMatches.Add(new CharMatch(leftChar, leftIndex, rightIndex));
        //             }
        //         }
        //     }

        //     return allMatches;
        // }

        // public static string PalindromizeOther(string input)
        // {
        //     // return PalindromizeOld(input);
        //     var i = 0;
        //     while (i <= input.Length / 2)
        //     {
        //         int leftIndex = i;
        //         int rightIndex = input.Length - 1 - i;
        //         char leftChar = input[leftIndex];
        //         char rightChar = input[rightIndex];
        //         int comparison = Math.Sign(leftChar.CompareTo(rightChar));
        //         if (comparison != 0)
        //         {
        //             switch (comparison)
        //             {
        //                 case -1:
        //                     // drop
        //                     break;
        //                 case 1:
        //                     // right
        //                     break;
        //             }
        //             i++;
        //         }
        //     }
        //     return input;
        // }
        // public static string PalindromizeInner(string input)
        // {
        //     System.Diagnostics.Debug.WriteLine(PalindromeMissing(input));
        //     var substrings = AllSubStrings(input);
        //     var masks = substrings.Select(t => new { From = t.from, Text = t.text, Mask = PalindromeMask(t.text) });
        //     var mostMaskCharacters = masks.OrderByDescending(k => k.Mask.Length).Select(k => new { k.Mask, k.Text, k.From, Score = k.Mask.Where(b => b).Count() }).OrderByDescending(s => s.Score).ToArray();
        //     foreach (var substring in mostMaskCharacters.Where(x => x.Score == mostMaskCharacters[0].Score))
        //     {
        //         System.Diagnostics.Debug.WriteLine("");
        //         System.Diagnostics.Debug.WriteLine(substring.From);
        //         System.Diagnostics.Debug.WriteLine(string.Join(('\t').ToString(), substring.Text.ToCharArray()));
        //         System.Diagnostics.Debug.WriteLine(string.Join(('\t').ToString(), substring.Mask));
        //         System.Diagnostics.Debug.WriteLine(PalindromeMissing(substring.Text));
        //     }
        //     return input;
        // }
        // private static bool[] PalindromeMask(string input)
        // {
        //     var ret = new bool[input.Length];
        //     var i = 0;
        //     while (i <= input.Length / 2)
        //     {
        //         int leftIndex = i;
        //         int rightIndex = input.Length - 1 - i;
        //         char leftChar = input[leftIndex];
        //         char rightChar = input[rightIndex];
        //         if (leftChar == rightChar)
        //         {
        //             ret[leftIndex] = true;
        //             ret[rightIndex] = true;
        //         }
        //         i++;
        //     }

        //     return ret;
        // }

        // private static IEnumerable<(string text, int from)> AllSubStrings(string input)
        // {
        //     for (int a = 0; a < input.Length; a++)
        //     {
        //         for (int b = 1; b <= input.Length - a; b++)
        //         {
        //             yield return (input.Substring(a, b), a);
        //         }
        //     }
        // }

        // public static string PalindromeMissing(string input)
        // {
        //     var i = 0;
        //     while (i <= input.Length / 2)
        //     {
        //         int leftIndex = i;
        //         int rightIndex = input.Length - 1 - i;
        //         char leftChar = input[leftIndex];
        //         char rightChar = input[rightIndex];
        //         int comparison = Math.Sign(leftChar.CompareTo(rightChar));
        //         char insertChar = leftChar;
        //         int insertIndex = rightIndex;
        //         Direction insertDirection = Direction.Right;
        //         if (comparison != 0)
        //         {
        //             if (comparison == 1)
        //             {
        //                 insertChar = rightChar;
        //                 insertIndex = leftIndex;
        //                 insertDirection = Direction.Left;
        //             }
        //             input = addLetterIn(input, insertChar, insertIndex, insertDirection);
        //         }
        //         i++;
        //     }
        //     return input;
        // }
        // [System.Diagnostics.DebuggerStepThrough]
        // private static Direction PickDirection(int comparison)
        // {
        //     Direction direction;
        //     switch (comparison)
        //     {
        //         case 1:
        //             direction = Solution034.Direction.Right;
        //             break;
        //         default:
        //             direction = Solution034.Direction.Left;
        //             break;
        //     }
        //     return direction;
        // }
        // private static string addLetterIn(string input, char letter, int place, Direction direction)
        // {
        //     input = input.Insert(place + (int)direction, letter.ToString());
        //     return input;
        // }
    }
}