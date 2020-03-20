using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common.Algorithm
{
    public static class DivideConquerer
    {

        public static T DivideAndConquer<T>(IEnumerable<T> array, Func<T, T, T> evaluator)

        {
            var divided = Divide(array, out var leftHalf, out var rightHalf);
            return Conquer(evaluator, leftHalf, rightHalf, divided);
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
        private static T Conquer<T>(Func<T, T, T> evaluator, IEnumerable<T> leftHalf, IEnumerable<T> rightHalf, bool divided)
        {
            if (!divided) { return evaluator(leftHalf.FirstOrDefault(), rightHalf.FirstOrDefault()); }
            else
            {
                T q = DivideAndConquer(leftHalf, evaluator);
                T q1 = DivideAndConquer(rightHalf, evaluator);
                return evaluator(q, q1);
            }
        }
    }
}