using System;

namespace Common
{
    public class Solution109
    {
        public static byte SwapOddEven(byte input)
        {
            // order of operation puts the bitshift first
            // then the AND operation, so this is a push
            // and grab, rather than a grab and push,
            // otherwise you lop off a bit at the end
            return (byte)((0b10101010 & input << 1) | (0b01010101 & input >> 1));
        }
    }
}