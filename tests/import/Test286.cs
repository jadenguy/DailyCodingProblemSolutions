// The skyline of a city is composed of several buildings of various widths and heights, possibly overlapping one another when viewed from a distance. We can represent the buildings using an array of (left, right, height) tuples, which tell us where on an imaginary x-axis a building begins and ends, and how tall it is. The skyline itself can be described by a list of (x, height) tuples, giving the locations at which the height visible to a distant observer changes, and each new height.
// Given an array of buildings as described above, create a function that returns the skyline.
// For example, suppose the input consists of the buildings [(0, 15, 3), (4, 11, 5), (19, 23, 4)]. In aggregate, these buildings would create a skyline that looks like the one below. 
//      ______  
//     |      |        ___
//  ___|      |___    |   | 
// |   |   B  |   |   | C |
// | A |      | A |   |   |
// |   |      |   |   |   |
// ------------------------
using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Test
{
    public class Test286
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        //[Test]
        public void Problem286()
        {
            //-- Assert

            //-- Arrange

            //-- Act
            Assert.Pass();
        }
    }
}
