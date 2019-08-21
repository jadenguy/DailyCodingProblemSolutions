using System;
using System.Linq;
using System.Security.Cryptography;

namespace Common.Test
{
    public class Solution059
    {
        public static ulong TransferFile(byte[] localFile, byte[] remoteFile, object fileSystem, object connection, int blockSize = 1000, int errorOnePer = 1000000, int maxRetry = 10)
        {
            ulong ret = 0;
            ulong tx = 0;
            ulong rx = 0;
            // var localFileTemp = new List<byte>();
            // one byte for the request message
            tx += 1;
            int length = RequestRemoteFileSize(connection, remoteFile);
            // four bytes for the received int size
            rx += 4;
            localFile = resizeLocalFile(localFile, length);
            int blockCount = length / blockSize;
            for (int i = 0; i < blockCount; i++)
            {
                var localBlock = GetBlock(fileSystem, localFile, blockSize, i);
                // one byte for the request message
                tx++;
                byte[] remoteCheckSum = GetRemoteCheckSum(connection, remoteFile, blockSize, i);
                // one byte back
                rx += (ulong)remoteCheckSum.Length;
                byte[] localCheckSum = checkSum(localBlock);
                var retry = 0;
                while (!localCheckSum.SequenceEqual(remoteCheckSum))
                {
                    tx++;
                    var remoteBlock = GetRemoteWithErrorRate(GetRemoteBlock(connection, remoteFile, blockSize, i), new byte[blockSize], errorOnePer / blockSize);
                    rx += (ulong)blockSize;
                    ReplaceBlock(fileSystem, localFile, blockSize, i, remoteBlock);
                    localBlock = GetBlock(fileSystem, localFile, blockSize, i);
                    localCheckSum = checkSum(localBlock);
                    retry++;
                    if (retry > maxRetry)
                    {
                        throw new Exception("Download failed, connection too unstable");
                    }
                }
            }
            ret = tx + rx;
            return ret;
        }
        private static T GetRemoteWithErrorRate<T>(T @return, T errorReturn, int errorOnePer)
        {
            if (new System.Random().Next(errorOnePer) == 0)
            {
                return errorReturn;
            }
            return @return;
        }
        private static byte[] resizeLocalFile(byte[] localFile, int length)
        {
            int localLength = localFile.Length;
            if (length != localLength)
            {
                var temp = new byte[length];
                Array.Copy(localFile, temp, Math.Min(length, localLength));
                localFile = temp;
            }
            return localFile;
        }
        private static void ReplaceBlock(object fileSystem, byte[] localFile, int blockSize, int i, byte[] remoteBlock)
        {
            Array.Copy(remoteBlock, 0, localFile, blockSize * i, blockSize);
        }
        private static byte[] GetRemoteBlock(object connection, byte[] file, int blockSize, int i)
        {
            return GetBlock(connection, file, blockSize, i);
        }
        private static byte[] GetRemoteCheckSum(object connection, byte[] remoteFile, int blockSize, int i)
        {
            var block = GetBlock(connection, remoteFile, blockSize, i).ToArray();
            byte[] remoteCheckSum = checkSum(block);
            return remoteCheckSum;
        }
        private static int RequestRemoteFileSize(object connection, byte[] remoteFile)
        {
            return remoteFile.Length;
        }
        private static byte[] GetBlock(object fileSystem, byte[] file, int blockSize, int index)
        {
            return file.Skip(blockSize * index).Take(blockSize).ToArray();
        }
        private static byte[] checkSum(byte[] block)
        {
            byte[] hash;
            using (MD5 md5 = MD5.Create())
            {
                hash = md5.ComputeHash(block);
            }
            return hash;
        }
    }
}