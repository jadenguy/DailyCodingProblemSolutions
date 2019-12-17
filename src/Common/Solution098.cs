using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace Common
{
    public class Solution098
    {
        public static bool DoesTextExist<T>(T[,] array, T[] sequence) where T : IEquatable<T>
        {
            var ret = false;
            if (sequence.IsNullOrEmpty()) { ret = true; }
            else
            {
                var collection = FindElement(array, sequence).ToArray();
                var stack = new Stack<ArraySearchResult>(collection);
                var current = stack.Peek();
                while (current != null && !current.IsDone && stack.Count > 0)
                {
                    current = stack.Pop();
                    var arraySearchResult = FindNextElement(array, sequence, current).ToArray();
                    foreach (var n in arraySearchResult)
                    {
                        stack.Push(n);
                        if (n.IsDone)
                        {
                            current = n;
                            // break;
                        };
                    }
                }
                ret = current?.IsDone ?? false;
            }
            return ret;
        }
        private static bool[,] MaskFromArray<T>(T[,] array)
        {
            GetDimensions(array, out var xLength, out var yLength);
            bool[,] mask = TwoDArrayWithInitialValues(xLength, yLength, true);
            return mask;
        }
        private static T[,] TwoDArrayWithInitialValues<T>(int xLength, int yLength, T value)
        {
            T[,] mask = new T[xLength, yLength];
            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    mask[x, y] = value;
                }
            }
            return mask;
        }
        public class ArraySearchResult
        {
            public ArraySearchResult(bool isDone, int index, bool[,] mask, int x, int y)
            {
                IsDone = isDone;
                Index = index;
                Mask = mask;
                X = x;
                Y = y;
            }
            public bool IsDone { get; set; }
            public int Index { get; internal set; }
            public bool[,] Mask { get; internal set; }
            public int X { get; internal set; }
            public int Y { get; internal set; }
            public override string ToString() => $"{Index}: {X},{Y}";
        }
        private static IEnumerable<ArraySearchResult> FindNextElement<T>(T[,] array, T[] sequence, ArraySearchResult current) where T : IEquatable<T>
        {
            return FindElement(array, sequence, current.Index + 1, current.Mask, current.X, current.Y, true);
        }
        private static IEnumerable<ArraySearchResult> FindElement<T>(T[,] array, T[] sequence, int index = 0, bool[,] mask = null, int x = 0, int y = 0, bool adjacent = false) where T : IEquatable<T>
        {
            T target = sequence[index];
            mask = mask ?? MaskFromArray(array);
            GetDimensions(array, out var xLength, out var yLength);
            var checkPlaces = new List<(int x, int y)>();
            var lookingForString = $"{sequence[index]} at {index}";
            if (adjacent)
            {
                System.Diagnostics.Debug.WriteLine($"searching for {lookingForString} next to {x},{y}");
                if (x > 0) { checkPlaces.Add((x - 1, y)); }
                if (x < xLength - 1) { checkPlaces.Add((x + 1, y)); }
                if (y > 0) { checkPlaces.Add((x, y - 1)); }
                if (y < yLength - 1) { checkPlaces.Add((x, y + 1)); }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"searching for {lookingForString} as first letter");
                for (int xPlace = 0; xPlace < xLength; xPlace++)
                {
                    for (int yPlace = 0; yPlace < yLength; yPlace++)
                    {
                        checkPlaces.Add((xPlace, yPlace));
                    }
                }
            }
            foreach (var place in checkPlaces)
            {
                bool checkablePlace = mask[place.x, place.y];
                T placeValue = array[place.x, place.y];
                bool isMatch = placeValue.Equals(target);
                if (checkablePlace && isMatch)
                {
                    bool isDone = index == sequence.Length - 1;
                    System.Diagnostics.Debug.WriteLine($"match {lookingForString} at {place.x},{place.y} as {isDone}");
                    bool[,] nextMask = (bool[,])mask.Clone();
                    nextMask[place.x, place.y] = false;
                    yield return new ArraySearchResult(isDone, index, nextMask, place.x, place.y);
                    if (isDone) { yield break; } // just work until you're done
                }
            }
            yield break;
        }
        private static void GetDimensions<T>(T[,] array, out int xLength, out int yLength)
        {
            xLength = array.GetUpperBound(0) + 1;
            yLength = array.GetUpperBound(1) + 1;
        }
    }
}