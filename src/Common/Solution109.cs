using System;

namespace Common
{
    public class Solution109
    {
        public static byte SwapOddEven(byte input)
        {
            return (byte)(((0b10101010 & input) >> 1) | ((0b01010101 & input) << 1));
        }
    }
}