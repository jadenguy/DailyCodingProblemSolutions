// Given a 2D board of characters and a word, find if the word exists in the grid.
// The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once.
// For example, given the following board:
// [
//   ['A','B','C','E'],
//   ['S','F','C','S'],
//   ['A','D','E','E']
// ]
// exists(board, "ABCCED") returns true, exists(board, "SEE") returns true, exists(board, "ABCB") returns false.

using NUnit.Framework;

namespace Common.Test
{
    public class Test098
    {
        char[,] array = new char[,]{
                {'A','B','C','E'},
                {'S','F','C','S'},
                {'A','D','E','E'}
            };
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase("ABCCED", true)]
        [TestCase("SA", true)]
        [TestCase("SEE", true)]
        [TestCase("ABCB", false)]
        [TestCase("X", false)]
        [TestCase("", true)]
        public void Problem098(string text, bool exists)
        {
            //-- Arrange0
            var expected = exists;

            //-- Act
            var actual = Solution098.DoesTextExist(array, text.ToCharArray());

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}