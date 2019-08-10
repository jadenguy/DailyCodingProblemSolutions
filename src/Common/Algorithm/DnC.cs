using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common.Algorithm
{
    public static class DnC
    {

        public static T DivideAndConquor<T>(IEnumerable<T> array, Func<T, T, T> evaluator)

        {
            var divided = Divide(array, out var leftHalf, out var rightHalf);
            return Conquor(evaluator, leftHalf, rightHalf, divided);
        }
        private static bool Divide<T>(IEnumerable<T> array, out IEnumerable<T> leftHalf, out IEnumerable<T> rightHalf)
        {
            int length = array.Count();
            int smallHalf = length / 2;
            int bigHalf = length - smallHalf;
            leftHalf = array.Take(bigHalf);
            rightHalf = array.TakeLast(smallHalf);
            return length <= 2;
        }
        private static T Conquor<T>(Func<T, T, T> evaluator, IEnumerable<T> leftHalf, IEnumerable<T> rightHalf, bool divided)
        {
            if (!divided) { return evaluator(leftHalf.FirstOrDefault(), rightHalf.FirstOrDefault()); }
            else
            {
                T q = DivideAndConquor(leftHalf, evaluator);
                T q1 = DivideAndConquor(rightHalf, evaluator);
                return evaluator(q, q1);
            }
        }
    }
}