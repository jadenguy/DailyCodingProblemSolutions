// Given a mapping of digits to letters (as in a phone number), and a digit string, return all possible letters the number could represent. You can assume each valid number in the mapping is a single digit.
// For example if {"2": ["a", "b", "c"], 3: ["d", "e", "f"], …} then "23" should return ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test081
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem081()
        {
            //-- Arrange
            var sequence = "23";
            var dict = new Dictionary<char, char[]>();
            dict.Add('2', new char[] { 'A', 'B', 'C' });
            dict.Add('3', new char[] { 'D', 'E', 'F' });
            dict.Add('4', new char[] { 'G', 'H', 'I' });
            dict.Add('5', new char[] { 'J', 'K', 'L' });
            dict.Add('6', new char[] { 'M', 'N', 'O' });
            dict.Add('7', new char[] { 'P', 'Q', 'R', 'S' });
            dict.Add('8', new char[] { 'T', 'U', 'V' });
            dict.Add('9', new char[] { 'W', 'X', 'Y', 'Z' });
            var expected = (new string[] { "AD", "AE", "AF", "BD", "BE", "BF", "CD", "CE", "CF" }).OrderBy(s => s);

            //-- Act
            var actual = Solution081.FindPossibilities(dict, sequence).OrderBy(s => s);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}