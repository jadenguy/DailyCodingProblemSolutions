using System.Linq;

namespace Common.Test
{
    public class Solution058
    {
        public static int? FindRotatedSortedArrayIndexDivideAndConquor(int[] array, int value, out int steps)
        {
            int? ret = null;
            var length = array.Length;
            var leftIndex = 0;
            var rightIndex = length - 1;
            bool done = false;
            int i = 0;
            while (!done && rightIndex >= leftIndex)
            {
                i++;
                var middleIndex = (rightIndex + leftIndex) / 2;
                var right = array[rightIndex];
                var middle = array[middleIndex];
                var left = array[leftIndex];
                // var subLength = rightIndex - leftIndex + 1; // for debugging what the current review section looked like
                // var sub = array.Skip(leftIndex).Take(subLength);
                if (value == left) { ret = leftIndex; }
                else if (value == right) { ret = rightIndex; }
                else if (value == middle) { ret = middleIndex; }
                if (ret != null)
                {
                    done = true;
                }
                else if (middle < value && value < right) { leftIndex = middleIndex; } //inspect right half next, value between right half ranges
                else if (left < value && value < middle) { rightIndex = middleIndex; } //inspect left half next, value between left half ranges
                else if (right < middle) { leftIndex = middleIndex; } // go left if there's an inversion on the left
                else if (middle < left) { rightIndex = middleIndex; } // go right if there's an inversion to the right
                else { done = true; } // outside of range and no inversions to be seen
                leftIndex++;
                rightIndex--;
            }
            steps = i * 3; //three comparisons kinda
            return ret;
        }
        public static int? FindRotatedSortedArrayIndexNaive(int[] array, int value, out int steps)
        {
            int? ret = null;
            var direction = value.CompareTo(array[0]); // pick which direction to move
            int i;
            for (i = 0; ret == null && i < array.Length; i++)
            {
                int index = (array.Length + (i * direction)) % array.Length;
                if (array[index] == value)
                {
                    ret = index;
                }
            }
            steps = i * 2; //two comparisons kinda
            return ret;
        }
    }
}