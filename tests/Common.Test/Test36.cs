// Given a string, find the palindrome that can be made by inserting the fewest number of characters as possible anywhere in the word. If there is more than one palindrome of minimum length that can be made, return the lexicographically earliest one (the first one alphabetically).
// For example, given the string "race", you should return "ecarace", since we can add three letters to it (which is the smallest amount to make a palindrome). There are seven other palindromes that can be made from "race" by adding three letters, but "ecarace" comes first alphabetically.
// As another example, given the string "google", you should return "elgoogle".


using Common.Node;
using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test036
    {
        // [SetUp]
        // public void Setup() { }
        // [TearDown]
        // public void TearDown() { }
        [Test]
        public void Problem036()
        {
            //-- Arrange
            var expected = new BinarySearchNode(14);
            var tree = new BinarySearchNode(7);
            tree.Add(new int[] { 10, 11, 8, 9, 14, 15, 12, 13, 2, 3, 0, 1, 6, 4, 5 });

            //-- Act
            BinarySearchNode actual = Solution36.SecondLargestNodeInTree(tree);

            //-- Assert
            Assert.AreEqual(expected.Data, actual.Data);
        }
    }
}