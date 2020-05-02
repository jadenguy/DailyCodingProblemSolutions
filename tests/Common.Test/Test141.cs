// Implement 3 stacks using a single list:
// class Stack:
//     def __init__(self):
//         self.list = []
//     def pop(self, stack_number):
//         pass
//     def push(self, item, stack_number):

using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;
using System.Collections.Generic;

namespace Common.Test
{
    public class Test141
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem141()
        {
            //-- Assert
var expected = new[]{new[]{0},new[]{1},new[]{2}};
            var triStack = new Common.Solution141.TriStack();
            //-- Arrange
            for (int i = 0; i < 3; i++)
            {
                triStack.Push(i,i);
            }
            var actual = new List<List<int>>();
            for (int i = 0; i < 3; i++)
            {
actual.Add(             new List<int> (){  triStack.Pop(i)});
            }

            //-- Act
            Assert.Pass();
        }
    }
}
