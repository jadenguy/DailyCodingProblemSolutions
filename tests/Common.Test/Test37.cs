// The power set of a set is the set of all its subsets. Write a function that, given a set, generates its power set.
// For example, given the set {1, 2, 3}, it should return {{}, {1}, {2}, {3}, {1, 2}, {1, 3}, {2, 3}, {1, 2, 3}}.
// You may also use a list or array to represent a set.

using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Common.Test
{
    public class Test037
    {
        // [SetUp]
        // public void Setup() { }
        // [TearDown]
        // public void TearDown() { }
        [Test]
        [TestCase("123", new string[] { "", "1", "2", "3", "12", "13", "23", "123" })]
        public void Problem037(string input, string[] results)
        {
            //-- Arrange
            var expected = Sort(results);

            //-- Act
            var actual = Sort(Solution37.PowerSet(input).Select(k => string.Join(null, k)));

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        private static IOrderedEnumerable<string> Sort(IEnumerable<string> expected)
        {
            return expected.OrderBy(k => k.FirstOrDefault()).OrderBy(k => k.Length);
        }
    }
}