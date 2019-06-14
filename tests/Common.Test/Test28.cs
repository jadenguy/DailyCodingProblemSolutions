// Write an algorithm to justify text. Given a sequence of words and an integer line length k, return a list of strings which represents each line, fully justified.
// More specifically, you should have as many words as possible in each line. There should be at least one space between each word. Pad extra spaces when necessary so that each line has exactly length k. Spaces should be distributed as equally as possible, with the extra spaces, if any, distributed starting from the left.
// If you can only fit one word on a line, then you should pad the right-hand side with spaces.
// Each word is guaranteed not to be longer than k.
// For example, given the list of words ["the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog"] and k = 16, you should return the following:
// ["the  quick brown", # 1 extra space on the left
// "fox  jumps  over", # 2 extra spaces distributed evenly
// "the   lazy   dog"] # 4 extra spaces distributed evenly


using NUnit.Framework;

namespace Common.Test
{
    public class Test28
    {


        [SetUp]
        public void Setup() { }
        [Test]
        [TestCase(new string[] { "the", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" }, 16, new string[] { "the  quick brown", "fox  jumps  over", "the   lazy   dog" })]
        public void Problem27(string[] input, int k, string[] results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            var actual = Solution28.Justify(input, k);

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
        [Test]
        [TestCase(new string[] { "the", "quick", "brown" }, ' ', 16, "the  quick brown")]
        [TestCase(new string[] { "fox", "jumps", "over" }, ' ', 16, "fox  jumps  over")]
        [TestCase(new string[] { "the", "lazy", "dog" }, ' ', 16, "the   lazy   dog")]
        [TestCase(new string[] { "x" }, ' ', 16, "x               ")]
        public void JustifyLine(string[] words, char spacer, int size, string output)
        {
            //-- Arrange
            var expected = output;
            //-- Act
            var actual = Solution28.JustifyJoin(words, spacer, size);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}