// This problem was asked by Google.
// Implement a file syncing algorithm for two computers over a low-bandwidth network. What if we know the files in the two computers are mostly the same?


// my reaction:
// so basically, rewrite rSync?

using System;
using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test059
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem059()
        {
            //-- Arrange
            int totalBytes = 1000000;
            int deltaBytes = 4321;
            const int blockSize = 1000;

            var rand = new Random();
            var seed = rand.Next();
            var file1 = RandomFile(seed, totalBytes);
            byte[] file2 = RandomDifferentFile(file1, totalBytes, deltaBytes, rand.Next());
            var expected = deltaBytes + (totalBytes / blockSize);

            //-- Act

            object fileSystem = new object();
            object connection = new object();
            var actual = Solution059.TransferFile(file1, file2, fileSystem, connection, blockSize); //minimum overhead equal to the block count plus file size

            // //-- Assert
            Assert.AreEqual(file1, file2);
            bool savedFileTransferBytes = totalBytes.CompareTo(actual) > 0;
            Assert.IsTrue(savedFileTransferBytes, "transfer smaller than whole file");
            if (savedFileTransferBytes)
            {
                System.Console.WriteLine(expected - actual);
                Assert.AreEqual(expected, actual, blockSize * 2, "within 2 blocks of unique bytes");
            }
        }

        private static byte[] RandomDifferentFile(byte[] file, int totalBytes, int uniqueBytes, int seed)
        {
            var ret = new byte[totalBytes];
            int repeatBytes = totalBytes - uniqueBytes;
            var repeatedStart = file.Take(repeatBytes / 2).ToArray();
            var repeatedEnd = file.Skip(uniqueBytes + (repeatBytes / 2)).Take(repeatBytes - repeatBytes / 2).ToArray();
            var uniquePart = RandomFile(seed, uniqueBytes);
            Array.Copy(repeatedStart, ret, repeatBytes / 2);
            Array.Copy(uniquePart, 0, ret, repeatBytes / 2, uniqueBytes);
            Array.Copy(repeatedEnd, 0, ret, uniqueBytes + (repeatBytes / 2), repeatBytes - repeatBytes / 2);
            return ret;
        }

        private static byte[] RandomFile(int seed, int elementCount)
        {
            var rand = new Random(seed);
            byte[] file = new byte[elementCount];
            rand.NextBytes(file);
            return file;
        }
    }
}