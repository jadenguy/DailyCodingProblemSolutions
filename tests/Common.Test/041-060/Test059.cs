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
        // [TestCase(1, 0, 1)]
        // [TestCase(100, 0, 1)]
        // [TestCase(100, 0, 20, 1000000)] //more efficient once block size exceeds 16 bytes (md5 return size) plus a few overhead bytes 
        // [TestCase(100000, 0, 100, 1000000)] //more efficient once block size exceeds 16 bytes (md5 return size) plus a few overhead bytes 
        [TestCase(100000, 0, 1000, 1000000)] //more efficient once block size exceeds 16 bytes (md5 return size) plus a few overhead bytes 
        [TestCase(1000000, 0, 10000, 1000000)] //more efficient once block size exceeds 16 bytes (md5 return size) plus a few overhead bytes 
        [TestCase(1000000, 432100, 10000, 1000000)] //more efficient once block size exceeds 16 bytes (md5 return size) plus a few overhead bytes 
        [TestCase(1000000, 543210, 10000, 1000000)] //more efficient once block size exceeds 16 bytes (md5 return size) plus a few overhead bytes 
        // [TestCase(100000000, 54321000, 100000, 1000000)] //more efficient once block size exceeds 16 bytes (md5 return size) plus a few overhead bytes 
        // [TestCase(100000000, 54321000, 1000000, 1000000)] //more efficient once block size exceeds 16 bytes (md5 return size) plus a few overhead bytes 
        // [TestCase(100000000, 54321000, 1000000, 100000000)] //more efficient once block size exceeds 16 bytes (md5 return size) plus a few overhead bytes 
        public void Problem059(int totalBytes = 1000000, int deltaBytes = 1000000, int blockSize = 1000000, int connectionErrorRate = 100000000)
        {
            //-- Arrange
            var expected = deltaBytes;
            int blockCount = totalBytes / blockSize;
            int handshakeBytes = 5;
            int twoBlocksOfBytes = blockSize * 2;
            int blockChecksumOverhead = 17 * blockCount;
            var delta = twoBlocksOfBytes + blockChecksumOverhead + handshakeBytes; //5 percent overhead for failure of connection
            var rand = Rand.NewRandom(59);
            var file1 = RandomFile(rand.Next(), totalBytes);
            byte[] file2 = RandomDifferentFile(file1, totalBytes, deltaBytes, rand.Next());
            object fileSystem = new object();
            object connection = new object();

            //-- Act
            int actual = (int)Solution059.TransferFile(file1, file2, fileSystem, connection, blockSize, connectionErrorRate); //minimum overhead equal to the block count plus file size

            // //-- Assert
            int bitsTransmittedOverUniqueBits = actual - expected;
            int percentageOfBitsTransmittedOverUniqueBits = (bitsTransmittedOverUniqueBits * 100) / totalBytes;
            System.Console.WriteLine($"{bitsTransmittedOverUniqueBits} bytes more than {expected} required ");
            System.Console.WriteLine($"{percentageOfBitsTransmittedOverUniqueBits}% overage");
            Assert.AreEqual(file1, file2, "file not transferred");
            Assert.IsTrue(totalBytes.CompareTo(actual) > 0, "not more efficient");
            Assert.AreEqual(0, percentageOfBitsTransmittedOverUniqueBits, 5, "efficiency under 5 percent"); //peak efficiency testing
            // Assert.AreEqual(expected, actual, delta, "not within 2 blocks of unique bytes, something went wrong"); //peak efficiency testing
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
            var rand = Rand.NewRandom(seed);
            byte[] file = new byte[elementCount];
            rand.NextBytes(file);
            return file;
        }
    }
}