using System.Collections.Generic;
using System.Linq;

namespace Common.Test
{
    public class Solution059
    {
        public static int TransferFile(byte[] localFile, byte[] remoteFile, int blockSize = 1000)
        {
            var ret = 0;
            var localFileTemp = new List<byte>();
            int length = remoteFile.Length;
            for (int i = 0; i < length / blockSize; i++)
            {
                var localBlock = GetBlock(localFile, blockSize, blockSize * i).ToArray();
                byte localCheckSum = checkSum(localBlock);
                System.Diagnostics.Debug.WriteLine(localCheckSum);
            }
            return ret;
        }

        private static IEnumerable<byte> GetBlock(byte[] localFile, int blockSize, int blockStart)
        {
            return localFile.Skip(blockStart).Take(blockSize);
        }

        private static byte checkSum(IEnumerable<byte> block)
        {
            byte checksum = default(byte);
            foreach (var byteItem in block) // using xor as rudimentary checksum
            {
                checksum ^= byteItem;
            }
            return checksum;
        }
    }
}