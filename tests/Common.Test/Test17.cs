// Suppose we represent our file system by a string in the following manner:
// The string "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext" represents:
// dir
//     subdir1
//     subdir2
//         file.ext
// The directory dir contains an empty sub-directory subdir1 and a sub-directory subdir2 containing a file file.ext.
// The string "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext" represents:
// dir
//     subdir1
//         file1.ext
//         subsubdir1
//     subdir2
//         subsubdir2
//             file2.ext
// The directory dir contains two sub-directories subdir1 and subdir2. subdir1 contains a file file1.ext and an empty second-level sub-directory subsubdir1. subdir2 contains a second-level sub-directory subsubdir2 containing a file file2.ext.
// We are interested in finding the longest (number of characters) absolute path to a file within our file system. For example, in the second example above, the longest absolute path is "dir/subdir2/subsubdir2/file2.ext", and its length is 32 (not including the double quotes).
// Given a string representing the file system in the above format, return the length of the longest absolute path to a file in the abstracted file system. If there is no file in the system, return 0.
// Note:
// The name of a file contains at least a period and an extension.
// The name of a directory or sub-directory will not contain a period.

using Common.FileSystem;
using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test17
    {
        [SetUp]
        public void SetUp()
        {
        }
        [Test]
        [TestCase("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext", "dir/subdir2/subsubdir2/file2.ext")]
        public void Problem17(string tree, string longestFilePath)
        {
            //-- Arrange
            var expected = longestFilePath;

            //-- Act
            var actual = Solution17.LongestPath(tree);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void NewDirectory()
        {
            var dir = new Directory("dir");
            System.Diagnostics.Debug.WriteLine(dir, dir.Name);
            dir.AddFSO("this", FileSystemObjectType.Directory);
            dir.AddFSO("that", FileSystemObjectType.Directory);
            dir.AddFSO("other", FileSystemObjectType.File);
            foreach (var item in dir)
            {
                System.Diagnostics.Debug.WriteLine(item, item.Name);
            }

        }
    }
}
