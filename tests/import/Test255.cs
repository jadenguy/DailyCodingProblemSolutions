// The transitive closure of a graph is a measure of which vertices are reachable from other vertices. It can be represented as a matrix M, where M[i][j] == 1 if there is a path between vertices i and j, and otherwise 0.
// For example, suppose we are given the following graph in adjacency list form:
// graph = [
//     [0, 1, 3],
//     [1, 2],
//     [2],
//     [3]
// ]
// The transitive closure of this graph would be:
// [1, 1, 1, 1]
// [0, 1, 1, 0]
// [0, 0, 1, 0]
// [0, 0, 0, 1]
using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Test
{
    public class Test255
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        //[Test]
        public void Problem255()
        {
            //-- Assert

            //-- Arrange

            //-- Act
            Assert.Pass();
        }
    }
}
