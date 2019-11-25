// We"re given a hashmap associating each courseId key with a list of courseIds values, which represents that the prerequisites of courseId are courseIds. Return a sorted ordering of courses such that we can finish all courses.
// Return null if there is no such ordering.
// For example, given {"CSC300": ["CSC100", "CSC200"], "CSC200": ["CSC100"], "CSC100": []}, should return ["CSC100", "CSC200", "CSC300"].


using System;
using System.Collections.Generic;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    public class Test092
    {
        List<Dictionary<string, string[]>> scheduleRuleSets;
        List<string[]> results;

        private BinaryNode<string> n(object v) => n(v.ToString());
        [SetUp]
        public void Setup()
        {
            scheduleRuleSets = new List<Dictionary<string, string[]>>();
            results = new List<string[]>();
            var rand = new Random();

            // 0
            var ruleSet = new Dictionary<string, string[]>();
            ruleSet.Add("CSC300", new string[] { "CSC100", "CSC200" });
            ruleSet.Add("CSC200", new string[] { "CSC100" });
            ruleSet.Add("CSC100", new string[] { });
            scheduleRuleSets.Add(ruleSet);
            results.Add(new string[] { "CSC100", "CSC200", "CSC300" });

        }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase()]
        public void Problem092(int testCase = 0)
        {
            //-- Arrange
            var expected = results[testCase];
            var scheduleRulesSet = scheduleRuleSets[testCase];

            //-- Act
            var actual = Solution092.Order(scheduleRulesSet);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}