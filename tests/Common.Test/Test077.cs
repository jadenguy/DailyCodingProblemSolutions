// Given a list of possibly overlapping intervals, return a new list of intervals where all overlapping intervals have been merged.
// The input list is not necessarily ordered in any way.
// For example, given [(1, 3), (5, 8), (4, 10), (20, 25)], you should return [(1, 3), (4, 10), (20, 25)].


using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test077
    {
        [SetUp]
        public void Setup()
        {
            var testCase = new List<(int, int)[]>();
            var testResult = new List<(int, int)[]>();
            testCase.Add(new (int, int)[] { (5, 10), (4, 8), (1, 3), (20, 25) });
            testResult.Add(new (int, int)[] { (1, 3), (4, 10), (20, 25) });

            testCase.Add(new (int, int)[] {
                (43,51),
                (21,29),
                (7,15),
                (37,45),
                (22,30),
                (2,10),
                (9,17),
                (40,48),
                (30,38),
                (45,53),
                (17,25),
                (28,36),
                (14,22),
                (29,37),
                (20,28),
                (18,26),
                (27,35),
                (25,33),
                (12,20),
                (42,50),
                (19,27),
                (36,44),
                (3,11),
                (13,21),
                (16,24),
                (32,40),
                (38,46),
                (26,34),
                (4,12),
                (10,18),
                (23,31),
                (46,54),
                (34,42),
                (24,32),
                (35,43),
                (31,39),
                (39,47),
                (11,19),
                (41,49),
                (33,41),
                (15,23),
                (5,13),
                (6,14),
                (44,52),
                (1,9),
                (8,16)
                });
            testResult.Add(new (int, int)[] { (1, 54) });
            testCases = testCase.ToArray();
            testResults = testResult.ToArray();
        }
        // [TearDown] public void TearDown(){}
        (int, int)[][] testCases;
        (int, int)[][] testResults;

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        public void Problem077(int testIndex)
        {
            //-- Arrange
            var array = testCases[testIndex];
            var expected = testResults[testIndex];

            //-- Act
            var actual = Solution077.MergedOverlapping(array);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}