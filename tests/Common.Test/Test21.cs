// Given an array of time intervals (start, end) for classroom lectures (possibly overlapping), find the minimum number of rooms required.
// For example, given [(30, 75), (0, 50), (60, 150)], you should return 2.
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Common.Test
{
    public class Test021
    {

        
        [SetUp]
        public void Setup()
        {
            
        }
        [Test]
        public void Problem21()
        {
            //-- Arrange
            var expected = 2;
            var rangeArray = new (int, int)[] { (30, 75), (0, 50), (60, 150) };

            //-- Act
            var actual = Solution21.MaxConcurrent(rangeArray);

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}