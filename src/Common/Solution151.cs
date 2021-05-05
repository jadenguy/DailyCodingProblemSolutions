using System.Collections.Generic;

namespace Common
{
    public class Solution151
    {
        public enum Color
        {
            Black, White, Green
        }
        public static Color[,] FloodColor(Color[,] colors, int x, int y, Color fillColor)
        {
            var ret = CloneColorGrid(colors);
            int xCount = colors.GetUpperBound(0) + 1;
            int yCount = colors.GetUpperBound(1) + 1;
            var replaceColor = colors[x, y];
            var toReview = new Queue<(int, int)>();
            var reviewed = new HashSet<(int, int)>();
            toReview.Enqueue((x, y));
            while (toReview.Count > 0)
            {
                (var posX, var posY) = toReview.Dequeue();
                if (
                    !reviewed.Contains((posX, posY))
                    && posX >= 0
                    && posX < xCount
                    && posY >= 0
                    && posY < yCount
                    && ret[posX, posY] == replaceColor
                )
                {
                    ret[posX, posY] = fillColor;
                    toReview.Enqueue((posX, posY - 1));
                    toReview.Enqueue((posX, posY + 1));
                    toReview.Enqueue((posX - 1, posY));
                    toReview.Enqueue((posX + 1, posY));
                }
            }
            return ret;
        }
        private static Color[,] CloneColorGrid(Color[,] colors)
        {
            int xCount = colors.GetUpperBound(0) + 1;
            int yCount = colors.GetUpperBound(1) + 1;
            var ret = new Color[xCount, yCount];
            for (int xIndex = 0; xIndex < xCount; xIndex++)
            {
                for (int yIndex = 0; yIndex < yCount; yIndex++)
                {
                    ret[xIndex, yIndex] = colors[xIndex, yIndex];
                }
            }
            return ret;
        }
    }
}