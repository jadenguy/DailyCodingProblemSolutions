// We"re given a hashmap associating each courseId key with a list of courseIds values, which represents that the prerequisites of courseId are courseIds. Return a sorted ordering of courses such that we can finish all courses.
// Return null if there is no such ordering.
// For example, given {"CSC300": ["CSC100", "CSC200"], "CSC200": ["CSC100"], "CSC100": []}, should return ["CSC100", "CSC200", "CSC300"].


using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test092
    {
        List<Dictionary<string, string[]>> scheduleRuleSets;
        List<string[]> results;
        [SetUp]
        public void Setup()
        {
            scheduleRuleSets = new List<Dictionary<string, string[]>>();
            results = new List<string[]>();
            var rand = Rand.NewRandom(092);

            // 0
            var ruleSet = new Dictionary<string, string[]>();
            ruleSet.Add("CSC300", new string[] { "CSC100", "CSC200" });
            ruleSet.Add("CSC200", new string[] { "CSC100" });
            ruleSet.Add("CSC100", new string[] { });
            scheduleRuleSets.Add(ruleSet);
            results.Add(new string[] { "CSC100", "CSC200", "CSC300" });

            // 1
            ruleSet = new Dictionary<string, string[]>();
            ruleSet.Add("D", new string[] { "C", "B", "A" });
            ruleSet.Add("C", new string[] { "B", "A" });
            ruleSet.Add("B", new string[] { "A" });
            ruleSet.Add("A", new string[] { });
            ruleSet.Add("1", new string[] { });
            ruleSet.Add("2", new string[] { "1" });
            ruleSet.Add("CSC100", new string[] { });
            scheduleRuleSets.Add(ruleSet);
            results.Add(new string[] { "1", "A", "CSC100", "2", "B", "C", "D" });

            // 2
            ruleSet = new Dictionary<string, string[]>();
            ruleSet.Add("B", new string[] { "A" });
            ruleSet.Add("A", new string[] { "B" });
            scheduleRuleSets.Add(ruleSet);
            results.Add(null);

            // 3
            ruleSet = new Dictionary<string, string[]>();
            ruleSet.Add("B", new string[] { "A" });
            // ruleSet.Add("A", new string[] { "B" });
            scheduleRuleSets.Add(ruleSet);
            results.Add(null);

        }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
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
        // [Test]
        // uncomment to run every test at once
        public void Problem092All()
        {
            if (scheduleRuleSets.Count == results.Count)
            {
                for (int testCase = 0; testCase < scheduleRuleSets.Count; testCase++)
                {
                    Problem092(testCase);
                }
            }
            else
            {
                Assert.Fail("Test cases and results count mismatch.");
            }
        }
    }
}