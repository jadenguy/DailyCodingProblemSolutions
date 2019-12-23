// You are in an infinite 2D grid where you can move in any of the 8 directions:
//  (x,y) to
//     (x+1, y),
//     (x - 1, y),
//     (x, y+1),
//     (x, y-1),
//     (x-1, y-1),
//     (x+1,y+1),
//     (x-1,y+1),
//     (x+1,y-1)
// You are given a sequence of points and the order in which you need to cover the points. Give the minimum number of steps in which you can achieve it. You start from the first point.
// Example:
// Input: [(0, 0), (1, 1), (1, 2)]
// Output: 2
// It takes 1 step to move from (0, 0) to (1, 1). It takes one more step to move from (1, 1) to (1, 2).

// You are in an infinite 2D grid where you can move in any of the 8 directions:
using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test100
    {
        List<(int, int)[]> places;
        List<int> steps;

        [SetUp]
        public void Setup()
        {
            places = new List<(int, int)[]>();
            steps = new List<int>();
            places.Add(new (int, int)[] { (0, 0), (1, 1), (1, 2) });
            steps.Add(2);
            places.Add(new (int, int)[] { (0, 0), (1, 1), (2, 2) });
            steps.Add(2);
            places.Add(new (int, int)[] { (0, 0), (1, 1), (2, 2), (3, 3) });
            steps.Add(3);
            places.Add(new (int, int)[] { (0, 0), (1, 1), (2, 2), (3, 3), (4, 4), (5, 5) });
            steps.Add(5);
            places.Add(new (int, int)[] { (0, 0), (1, 1), (1, 0) });
            steps.Add(2);

        }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void Problem100(int testIndex)
        {
            //-- Arrange
            var expected = steps[testIndex];

            //-- Act
            var actual = Solution100.FewestSteps(places[testIndex]);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem100()
        {
            for (int i = 0; i < steps.Count; i++)
            {
                Problem100(i);
            }
        }
    }
}