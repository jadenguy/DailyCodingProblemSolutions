using System.Collections.Generic;

namespace Common
{
    public class Solution065
    {
        enum Direction
        {
            Down, Left, Up, Right
        }
        public static T[] UnwindArray<T>(T[,] array)
        {
            var ret = new List<T>();
            if (array.Length > 0)
            {
                var startWidth = 0;
                var startHeight = 1;
                var endWidth = array.GetUpperBound(1);
                var endHeight = array.GetUpperBound(0);
                var length = array.Length;
                var x = 0;
                var y = 0;
                Direction direction = Direction.Right;
                for (int i = 0; i < length; i++)
                {
                    ret.Add(array[y, x]);
                    move(ref startWidth, ref startHeight, ref endWidth, ref endHeight, ref x, ref y, ref direction);
                }
            }
            return ret.ToArray();
        }
        private static void move(ref int startWidth, ref int startHeight, ref int endWidth, ref int endHeight, ref int x, ref int y, ref Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    if (x == endWidth) { direction = turnDown(ref endWidth, ref y); } else { x++; }
                    break;
                case Direction.Down:
                    if (y == endHeight) { direction = turnLeft(ref endHeight, ref x); } else { y++; }
                    break;
                case Direction.Left:
                    if (x == startWidth) { direction = turnUp(ref startWidth, ref y); }
                    else { x--; }
                    break;
                case Direction.Up:
                    if (y == startHeight) { direction = turnRight(ref startHeight, ref x); }
                    else { y--; }
                    break;
                default:
                    break;
            }
        }
        private static Direction turnRight(ref int startHeight, ref int x)
        {
            startHeight++;
            x++;
            return Direction.Right;
        }
        private static Direction turnUp(ref int startWidth, ref int y)
        {
            startWidth++;
            y--;
            return Direction.Up;
        }
        private static Direction turnLeft(ref int endHeight, ref int x)
        {
            endHeight--;
            x--;
            return Direction.Left;
        }
        private static Direction turnDown(ref int endWidth, ref int y)
        {
            endWidth--;
            y++;
            return Direction.Down;
        }
    }
}