// Given a 2D matrix of characters and a target word, write a function that returns whether the word can be found in the matrix by going left-to-right, or up-to-down.
// For example, given the following matrix:
// [['F', 'A', 'C', 'I'],
//  ['O', 'B', 'Q', 'P'],
//  ['A', 'N', 'O', 'B'],
//  ['M', 'A', 'S', 'S']]
// and the target word 'FOAM', you should return true, since it's the leftmost column. Similarly, given the target word 'MASS', you should return true, since it's the last row.


using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test063
    {
        char[,] board;
        [SetUp]
        public void Setup()
        {
            board = new char[,] {{'F', 'A', 'C', 'I'},
                                {'O', 'B', 'Q', 'P'},
                                {'A', 'N', 'O', 'B'},
                                {'M', 'A', 'S', 'S'}};
        }
        [Test]
        [TestCase("BS", true)]
        [TestCase("CQ", true)]
        [TestCase("FOAM", true)]
        [TestCase("MASS", true)]
        [TestCase("GLIB", false)]
        public void Problem063(string text, bool result)
        {
            //-- Arrange
            var expected = result;

            //-- Act
            var words = Solution063.FindWord(board, text);
            var actual = words.Any();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}