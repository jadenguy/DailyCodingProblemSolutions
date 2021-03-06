﻿// Given a N by M matrix of numbers, print out the matrix in a clockwise spiral.
// For example, given the following matrix:
// [[1,  2,  3,  4,  5],
//  [6,  7,  8,  9,  10],
//  [11, 12, 13, 14, 15],
//  [16, 17, 18, 19, 20]]
// You should print out the following:
// 1
// 2
// 3
// 4
// 5
// 10
// 15
// 20
// 19
// 18
// 17
// 16
// 11
// 6
// 7
// 8
// 9
// 14
// 13
// 12


using NUnit.Framework;

namespace Common.Test
{
    public class Test065
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown(){}
        [Test]
        public void Problem065()
        {
            //-- Arrange
            int[] expected = { 1, 2, 3, 4, 5, 10, 15, 20, 19, 18, 17, 16, 11, 6, 7, 8, 9, 14, 13, 12 };
            var array = new int[,]{
                {1,  2,  3,  4,  5},
                {6,  7,  8,  9,  10},
                {11, 12, 13, 14, 15},
                {16, 17, 18, 19, 20}};

            //-- Act
            var actual = Solution065.UnwindArray(array);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}