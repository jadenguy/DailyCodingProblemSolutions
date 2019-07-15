// Given a dictionary of words and a string made up of those words (no spaces), return the original sentence in a list. If there is more than one possible reconstruction, return any of them. If there is no possible reconstruction, then return null.
// For example, given the set of words 'quick', 'brown', 'the', 'fox', and the string "thequickbrownfox", you should return ['the', 'quick', 'brown', 'fox'].
// Given the set of words 'bed', 'bath', 'bedbath', 'and', 'beyond', and the string "bedbathandbeyond", return either ['bed', 'bath', 'and', 'beyond] or ['bedbath', 'and', 'beyond'].

using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test022
    {


        [SetUp]
        public void Setup()
        {

        }
        [Test]
        [TestCase("thequickbrownfox", new string[] { "quick", "brown", "the", "fox" }, new string[] { "the", "quick", "brown", "fox" })]
        [TestCase("thequickbrownfox", new string[] { "theq", "quick", "brown", "the", "fox" }, new string[] { "the", "quick", "brown", "fox" })]
        [TestCase("5612889872", new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }, new string[] { "5", "6", "1", "2", "8", "8", "9", "8", "7", "2" })]

        public void Problem22(string text, string[] wordList, string[] sentence)
        {
            //-- Arrange
            var expected = sentence;

            //-- Act
            var actual = Solution22.ChopUpSourceText(text, wordList).First();

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}