// A rule looks like this:
// A NE B
// This means this means point A is located northeast of point B.
// A SW C
// means that point A is southwest of C.
// Given a list of rules, check if the sum of the rules validate. For example:
// A N B
// B NE C
// C N A
// does not validate, since A cannot be both north and south of C.
// A NW B
// A N B
// is considered valid.

using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test087
    {
        List<string[]> ruleSets;
        List<bool> results;
        [SetUp]
        public void Setup()
        {
            ruleSets = new List<string[]>();
            results = new List<bool>();
            ruleSets.Add(new string[] { "A NE B" });
            results.Add(true);
            ruleSets.Add(new string[] { "A SW C" });
            results.Add(true);
            ruleSets.Add(new string[] { "A N B", "B NE C", "C N A" });
            results.Add(false);
            ruleSets.Add(new string[] { "A NW B", "A N B" });
            results.Add(true);
        }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(0)]
        public void Problem087(int index)
        {
            //-- Arrange
            string[] ruleSet = ruleSets[index];
            var expected = results[index];

            //-- Act
            int actual = Solution087.Validate(ruleSet);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}