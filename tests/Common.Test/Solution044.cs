using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution044
    {
        public static int CountSorts<T>(T[] array, ref T steps)
        {
            var newArray = ChopArray(array).ToArray();
            return 0;
        }

        private static IEnumerable<T[]> ChopArray<T>(T[] array)
        {
            if (array.Length <= 2)
            {
                yield return array;
            }
            else
            {
                foreach (var item in ChopArray(array))
                {
                    yield return item;
                } ;
            }
        }
    }
}