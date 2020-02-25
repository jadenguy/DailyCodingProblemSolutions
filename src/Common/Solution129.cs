// Given a real number n, find the square root of n. For example, given n = 9, return 3

using System.Numerics;

namespace Common
{
    public static class Solution129
    {
        public static Complex SqRt(double n)
        {
            var imaginary = (n < 0);
            n = n * (imaginary ? -1 : 1);
            var top = n;
            var bottom = 0d;
            for (int i = 0; i < 1000; i++)
            {
                var max = top * top;
                var min = bottom * bottom;
                // WriterExtension.WriteHost($"IS {n} BETWEEN {bottom * bottom} AND {top * top}?");
                double delta = (top - bottom);
                if (n > max)
                {
                    (top, bottom) = (top + delta / 2, top);
                    // WriterExtension.WriteHost("\tNO HIGHER");
                }
                else if (n < min)
                {
                    (top, bottom) = (bottom, bottom - delta / 2d);
                    // WriterExtension.WriteHost("\tNO LOWER");
                }
                else
                {
                    // WriterExtension.WriteHost("\tYES");
                }
                delta = (top - bottom);
                var mid = bottom + (delta / 2d);
                // WriterExtension.WriteHost($"IS {n} CLOSER TO {bottom * bottom} OR {top * top} BASED ON {mid * mid}?");
                if (n == max)
                {
                    bottom = top;
                    // WriterExtension.WriteHost("\tIS TOP");
                }
                else if (n == min)
                {
                    top = bottom;
                    // WriterExtension.WriteHost("\tIS BOTTOM");
                }
                else if (n == mid * mid)
                {
                    (top, bottom) = (mid, mid);
                    // WriterExtension.WriteHost("\tIS MIDDLE");
                }
                else if (n > mid * mid)
                {
                    bottom = mid;
                    // WriterExtension.WriteHost("\tCLOSER TO TOP");
                }
                else if (n < mid * mid)
                {
                    top = mid;
                    // WriterExtension.WriteHost("\tCLOSER TO BOTTOM");
                }
                if (top == bottom)
                {
                    // i.WriteHost("SOLVED ITERATIONS");
                    break;
                }
            }
            return top * (imaginary ? Complex.ImaginaryOne : Complex.One);
        }
    }
}