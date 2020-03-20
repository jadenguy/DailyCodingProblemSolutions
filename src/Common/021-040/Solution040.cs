
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using Common.Sets;

namespace Common
{
    public class Solution040
    {
        public static int FindUnique(IEnumerable<int> arr)
        {
            //https://www.geeksforgeeks.org/find-the-element-that-appears-once/ 
            // for the original method, I knew it was Xor somehow, but didn't realize how
            int common_bit_mask, ones = 0, twos = 0;
            for (int i = 0; i < arr.Count(); i++)
            {
                int value = arr.ElementAt(i);

                // "one & value" gives the bits  
                // that are there in both 'ones'  
                // and new element from array.  
                // We add these bits to 'twos'  
                // using bitwise OR 
                twos = twos | (ones & value);

                // "one ^ value" removes bits  
                // that were just moved to the
                // 'twos', or adds the bits to
                // the ones.
                ones = ones ^ value;

                // The common bits are those bits  
                // which appear third time So these  
                // bits should not be there in both  
                // 'ones' and 'twos'. common_bit_mask 
                // contains all these bits as 0,  
                // so that the bits can be removed  
                // from 'ones' and 'twos' 
                common_bit_mask = ~(ones & twos);

                // Remove common bits (the bits that  
                // appear third time) from 'ones' 
                ones &= common_bit_mask;

                // Remove common bits (the bits that 
                // appear third time) from 'twos' 
                twos &= common_bit_mask;


                // print current results
                System.Diagnostics.Debug.WriteLine(i + 1, "runs");
                System.Diagnostics.Debug.WriteLine(value, "value");
                System.Diagnostics.Debug.WriteLine(ones, "ones");
                System.Diagnostics.Debug.WriteLine(twos, "twos");
                System.Diagnostics.Debug.WriteLine(common_bit_mask, "third");
                System.Diagnostics.Debug.WriteLine("");
            }
            return ones;
        }
        public static IEnumerable<T> FindUniqueUsingCommonSet<T>(IEnumerable<T> array) where T : IEquatable<T>
        {
            IEnumerable<T> threes, ones = new List<T>(), twos = new List<T>();
            var elementArrayArray = array.ToArrays();
            for (int i = 0; i < elementArrayArray.Count(); i++)
            {
                T[] value = elementArrayArray.ElementAt(i);

                // any new element that's already in ones should go to twos
                twos = twos.Or(ones.And(value).ToArray()).ToArray();

                // xor new elements to get repeats out of the ones and add new elements in
                ones = ones.Xor(value).ToArray();

                // since we moved some elements from ones to twos, if it's in ones again, this is the third time
                // throw the threes away when done
                // we could store them, but why
                threes = (ones.And(twos).ToArray()).ToArray();

                // remove threes from ones
                ones = ones.Not(threes).ToArray();

                // remove threes from twos
                twos = twos.Not(threes).ToArray();

                // print current results
                System.Diagnostics.Debug.WriteLine(i + 1, "runs");
                System.Diagnostics.Debug.WriteLine(value.Print(), "value");
                System.Diagnostics.Debug.WriteLine(ones.Print(","), "ones");
                System.Diagnostics.Debug.WriteLine(twos.Print(","), "twos");
                System.Diagnostics.Debug.WriteLine(threes.Print(), "third");
                System.Diagnostics.Debug.WriteLine("");
            }
            return ones;
        }
    }
}