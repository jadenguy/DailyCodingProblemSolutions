// Given a real number n, find the square root of n. For example, given n = 9, return 3

using System;
using System.Numerics;
using Common.Extensions;

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
                if (max < min) { (max, min) = (min, max); (bottom, top) = (top, bottom); }
                double delta = (top - bottom);
                WriteHost($"IS {n} BETWEEN {bottom * bottom} AND {top * top}?");
                if (n > max)
                {
                    (top, bottom) = (top + delta * 2d, top);
                    WriteHost("\tHIGHER");
                }
                else if (n < min)
                {
                    (top, bottom) = (bottom, bottom - delta * 2d);
                    WriteHost("\tLOWER");
                }
                else
                {
                    var mid = bottom + (delta / 2d);
                    WriteHost($"\tINSIDE. IS {n} CLOSER TO {bottom * bottom} OR {top * top} BASED ON {mid * mid}?");
                    if (n == max)
                    {
                        bottom = top;
                        WriteHost("\t\tIS TOP");
                    }
                    else if (n == min)
                    {
                        top = bottom;
                        WriteHost("\t\tIS BOTTOM");
                    }
                    else if (n == mid * mid)
                    {
                        (top, bottom) = (mid, mid);
                        WriteHost("\t\tIS MIDDLE");
                    }
                    else if (n > mid * mid)
                    {
                        bottom = mid;
                        WriteHost("\t\tCLOSER TO TOP");
                    }
                    else if (n < mid * mid)
                    {
                        top = mid;
                        WriteHost("\t\tCLOSER TO BOTTOM");
                    }
                    if (top == bottom)
                    {
                        i.WriteHost("SOLVED ITERATIONS");
                        break;
                    }
                }
            }
            return top * (imaginary ? Complex.ImaginaryOne : Complex.One);
        }
        private static void WriteHost(object o)
        {
            // Common.Extensions.WriterExtension.WriteHost(o);
            System.Diagnostics.Debug.WriteLine(o);
        }
        private static void WriteHost(object o, object h)
        {
            // Common.Extensions.WriterExtension.WriteHost(o, h);
            System.Diagnostics.Debug.WriteLine(o, h.ToString());
        }
    }
}