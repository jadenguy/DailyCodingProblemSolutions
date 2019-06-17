using System;

namespace Common
{
    public class Solution30
    {
        public static int FillWithWater(int[] array)
        {
            var ret = 0;
            if (array.Length > 2)
            {
                var leftWall = array[0]; //Higher wall will always be the 'left' wall
                var gutterLength = 0;
                var gutterFill = 0;
                int i = 1;
                while (i < array.Length - 1)
                {
                    int value = array[i];
                    if (value > leftWall)
                    {
                        leftWall = value;
                        gutterFill += gutterFill;
                        gutterFill = 0;
                        gutterLength = 0;
                    }
                    else
                    {
                        gutterFill += leftWall - value;
                        gutterLength++;
                    }
                    i++;
                }
                var rightWall = array[i];
                if (rightWall < leftWall)
                {
                    gutterFill -= gutterLength * (leftWall - rightWall);
                }
                ret += gutterFill;
            }
            return ret;
        }
    }
}