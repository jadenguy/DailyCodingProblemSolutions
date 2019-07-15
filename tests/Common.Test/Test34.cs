// Given a string, find the palindrome that can be made by inserting the fewest number of characters as possible anywhere in the word. If there is more than one palindrome of minimum length that can be made, return the lexicographically earliest one (the first one alphabetically).
// For example, given the string "race", you should return "ecarace", since we can add three letters to it (which is the smallest amount to make a palindrome). There are seven other palindromes that can be made from "race" by adding three letters, but "ecarace" comes first alphabetically.
// As another example, given the string "google", you should return "elgoogle".


using System;
using NUnit.Framework;

namespace Common.Test
{
    public class Test034
    {
        // [SetUp]
        // public void Setup() { }
        // [TearDown]
        // public void TearDown() { }
        [Test]
        [TestCase("x", "x")]
        [TestCase("abc", "abcba")]
        [TestCase("abzzzab", "abazzzaba")]
        [TestCase("bcba", "abcba")]
        [TestCase("race", "ecarace")]
        [TestCase("google", "elgoogle")]
        [TestCase("aaaaaaaaaaabbbc", "cbbbaaaaaaaaaaabbbc")]
        [TestCase("zzzzzzzzzzzzdcba", "abcdzzzzzzzzzzzzdcba")]
        public void Problem34(string input, string palindrome)
        {
            //-- Arrange
            var expected = palindrome;

            //-- Act
            var actual = Solution34.Palindromize(input);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}