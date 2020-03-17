// Implement a bit array.
// A bit array is a space efficient array that holds a value of 1 or 0 at each index.
// •	init(size): initialize the array with size
// •	set(i, val): updates index at i with val where val is either 1 or 0.
// •	get(i): gets the value at index i.


using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution137
    {
        public class BitArray
        {
            public int Size { get; }
            public int StorageSize { get => internalByteArray.Length; }
            private int[] internalByteArray;
            public bool this[int index] { get => Get(index); set => Set(index, value); }
            public BitArray(int size)
            {
                Size = size;
                internalByteArray = new int[size / 32];
            }
            public void Set(int index, bool value)
            {
                (int byteAddress, int bitAddress) = GetAddress(index);
                var bits = internalByteArray[byteAddress];
                var bit = bitAddress;
            }
            public bool Get(int index)
            {
                (int byteAddress, int bitAddress) = GetAddress(index);
                throw new NotImplementedException();
            }
            public IEnumerable<bool> GetValues() => Enumerable.Range(0, Size).Select(i => Get(i));
            private (int byteAddress, int bitAddress) GetAddress(int index)
            {
                if (index >= Size) { throw new IndexOutOfRangeException(); }
                int byteAddress = index / 32;
                int bitAddress = index % 32;
                return (byteAddress, bitAddress);
            }
            
        }
    }
}