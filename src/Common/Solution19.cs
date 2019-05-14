using System;
using System.Collections.Generic;

namespace Common
{
    public static class Solution19
    {
        public static int[] PickCheapestColorOptions(int[][] priceArray)
        {
            var choices = new List<int[]>();
            int houseCount = priceArray.Length;
            var bestChoice = new int[houseCount];
            for (int house = 1; house < houseCount; house++)
            {
                var currentArray = priceArray[house];
                var lastArray = priceArray[house - 1];
                var choice = new int[lastArray.Length];
                for (int currentArrayElement = 0; currentArrayElement < currentArray.Length; currentArrayElement++)
                {
                    choice[currentArrayElement] = -1;
                    var lowestValue = int.MaxValue;
                    for (int lastArrayElement = 1; lastArrayElement < lastArray.Length; lastArrayElement++)
                    {
                        var lastArrayOtherColorIndex = (currentArrayElement + lastArrayElement) % lastArray.Length;
                        var otherColorValue = lastArray[lastArrayOtherColorIndex];
                        if (otherColorValue < lowestValue)
                        {
                            choice[currentArrayElement] = lastArrayOtherColorIndex;
                            lowestValue = otherColorValue;
                        }
                    }
                    currentArray[currentArrayElement] += lastArray[choice[currentArrayElement]];
                }
                choices.Add(choice);
            }
            var bestGroup = -1;
            var bestGroupValue = int.MaxValue;
            int[] lastHouse = choices[choices.Count - 1];
            for (int i = 0; i < lastHouse.Length; i++)
            {
                int item = lastHouse[i];
                if (item < bestGroupValue)
                {
                    bestGroupValue = item;
                    bestGroup = i;
                }
            }
            choices.Add(new int[]{bestGroup});
            int previousGroup = 0;
            for (int i = houseCount - 1; i >= 0; i--)
            {
                bestChoice[i] = choices[i][previousGroup];
                if (i > 0) { previousGroup = choices[houseCount - i][previousGroup]; }
            }
            return bestChoice;
        }
    }
}