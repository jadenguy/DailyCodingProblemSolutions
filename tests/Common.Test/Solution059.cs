using System.Collections.Generic;
using System.Linq;

namespace Common.Test
{
    public class Solution059
    {
        public static int TransferFile(byte[] localFile, byte[] remoteFile, int blockSize = 1000)
        {
            var ret = 0;
            var localfile = new List<byte>();
            for (int i = 0; i < localFile.Length / blockSize; i++)
            {
                int blockIndex = blockSize * i;
                var block = localFile.Skip(blockIndex).Take(blockSize);
                byte checksum = checkSum(block);
                System.Diagnostics.Debug.WriteLine(checksum);
            }
            return ret;
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