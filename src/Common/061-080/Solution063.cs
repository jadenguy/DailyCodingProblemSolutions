using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Extensions;

namespace Common
{
    public class Solution063
    {
        public static IEnumerable<(int x, int y, int direction, string text)> FindWord(char[,] board, string text)
        {
            var enumerable = GetAllPossibilities(board, text);
            // System.Diagnostics.Debug.WriteLine(enumerable.Print());
            return enumerable.Where(w => w.text == text);
        }

        private static IEnumerable<(int x, int y, int direction, string text)> GetAllPossibilities(char[,] board, string text)
        {
            var ret = new StringBuilder();
            int length = text.Length;
            int xLength = board.GetUpperBound(0);
            int yLength = board.GetUpperBound(1);
            for (int x = 0; x <= xLength - length + 1; x++)
            {
                for (int y = 0; y <= yLength; y++)
                {
                    ret.Clear();
                    for (int i = 0; i < length; i++)
                    {
                        ret.Append(board[x + i, y]);
                    }
                    yield return (x, y, 0, ret.ToString());
                }
            }
            for (int y = 0; y <= yLength - length + 1; y++)
            {
                for (int x = 0; x <= xLength; x++)
                {
                    ret.Clear();
                    for (int i = 0; i < length; i++)
                    {
                        ret.Append(board[x, y + i]);
                    }
                    yield return (x, y, 1, ret.ToString());
                }
            }
        }
    }
}