﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public class Solution137
    {
        public class BitArray
        {
            public int Size { get; }
            public int StorageSize { get => internalClusterArray.Length; }
            public const string BitArrayExceptionMessage = "Out of array range";
            private const int ClusterSize = 8;
            private byte[] internalClusterArray;
            public bool this[int index] { get => Get(index); set => Set(index, value); }
            public BitArray(int size)
            {
                Size = size;
                internalClusterArray = new byte[(int)Math.Ceiling(size / (double)ClusterSize)];
            }
            public void Set(int index, bool value)
            {
                (int byteAddress, int bitAddress) = GetAddress(index);
                var bit = (byte)(1 << bitAddress);
                if (value) { internalClusterArray[byteAddress] |= bit; }
                else
                {
                    internalClusterArray[byteAddress] &= (byte)~bit;
                }
            }
            public bool Get(int index)
            {
                (int clusterIndex, int bitIndex) = GetAddress(index);
                var cluster = internalClusterArray[clusterIndex];
                var mask = 1 << bitIndex;
                return 1 == (cluster & mask) >> bitIndex;
            }
            public IEnumerable<bool> GetValues() => Enumerable.Range(0, Size).Select(i => Get(i));
            private (int byteAddress, int bitAddress) GetAddress(int index)
            {
                if (index >= Size || index < 0) { throw new IndexOutOfRangeException(BitArrayExceptionMessage); }
                int byteAddress = index / ClusterSize;
                int bitAddress = index % ClusterSize;
                return (byteAddress, bitAddress);
            }
        }
    }
}