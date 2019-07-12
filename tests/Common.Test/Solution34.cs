using System;

namespace Common.Test
{
    public class Solution34
    {

        enum Direction
        {
            Left = 0, Right = 1
        }
        public static string Palindromize(string input)
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
                switch (comparison)
                {
                    case 1:
                        insertChar = rightChar;
                        insertIndex = leftIndex;
                        insertDirection = Direction.Left;
                        break;
                    case 0:
                        i++;
                    break;
                }
                if (comparison != 0) { input = addLetterIn(input, insertChar, insertIndex, insertDirection); }
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