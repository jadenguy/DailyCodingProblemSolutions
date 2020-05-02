// Implement 3 stacks using a single list:
// class Stack:
//     def __init__(self):
//         self.list = []
//     def pop(self, stack_number):
//         pass
//     def push(self, item, stack_number):

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test141
    {

        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCase(3,10)]
        public void Problem141(int stacks, int reps)
        {
            //-- Assert
            var expected = Enumerable.Range(0, stacks)
                .Select(list => Enumerable.Range(0, reps)
                    .Select(n => stacks * (reps - n - 1) + list));
            var triStack = new Common.Solution141.NStack<int>(stacks);
            var actual = new List<List<int>>();
            var actualReuse = new List<List<int>>();
            for (int i = 0; i < stacks; i++)
            {
                actual.Add(new List<int>());
            actualReuse.Add(new List<int>());
            }

            //-- Arrange
            for (int i = 0; i < stacks * reps; i++)
            {
                triStack.Push(i % stacks, i);
            }
            for (int i = 0; i < stacks * reps; i++)
            {
                int list = i % stacks;
                actual[list].Add(triStack.Pop(list));
            }
            for (int i = 0; i < stacks * reps; i++)
            {
                triStack.Push(i % stacks, i);
            }
            for (int i = 0; i < stacks * reps; i++)
            {
                int list = i % stacks;
                actualReuse[list].Add(triStack.Pop(list));
            }

            //-- Act
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, actualReuse);
        }
    }
}
