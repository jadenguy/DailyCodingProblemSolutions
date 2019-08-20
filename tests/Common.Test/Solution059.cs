
using System.Linq;

namespace Common.Test
{
    public class Solution059
    {
        public static int TransferFile(byte[] localFile, byte[] remoteFile, int blockSize=1000)
        {
            var ret = 0;
            var localfile = new List<byte>();
            for (int i = 0; i < localFile.Length / blockSize; i++)
            {
                int blockIndex = blockSize * i;
                byte checksum = checkSum(localFile, blockSize, blockIndex);
                System.Diagnostics.Debug.WriteLine(checksum);
            }
            return ret;
        }

        private static byte checkSum(byte[] localFile, int blockSize, int blockIndex)
        {
            var enumerable = localFile.Skip(blockIndex).Take(blockSize);
            var checksum = default(byte);
            foreach (var item in enumerable)
            {
                checksum ^= item;
            }

            return checksum;
        }
    }
}