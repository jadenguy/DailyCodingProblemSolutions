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
            int totalBytes = 10000;
            int uniqueBytes = 4321;
            int repeatBytes = totalBytes - uniqueBytes;
            const int blockSize = 1000;
            
            var rand = new Random();
            var seed = rand.Next();
            var file1 = RandomFileMD5(seed, totalBytes);
            var file2 = file1.Take(repeatBytes).Union(RandomFileMD5(rand.Next(), uniqueBytes)).ToArray();
            var expected = uniqueBytes;

            //-- Act
            var actual = Solution059.TransferFile(file1, file2, blockSize);

            // //-- Assert
            Assert.AreEqual(file1, file2);
            Assert.AreEqual(expected, actual, blockSize);
        }
        private static byte[] RandomFileMD5(int seed, int elementCount)
        {
            var rand = new Random(seed);
            byte[] file = new byte[elementCount];
            rand.NextBytes(file);
            return file;
        }
    }
}