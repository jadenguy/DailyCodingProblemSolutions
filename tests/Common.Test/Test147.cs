// Given a list, sort it using this method: reverse(lst, i, j), which reverses lst from i to j.

using System.Linq;
using NUnit.Framework;
using Common.Extensions;
using System.Collections;

namespace Common.Test
{
    public class Test147
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases147))]
        public void Problem147(int[] array)
        {
            //-- Assert
            var expected = array;
            expected = array.OrderBy(n => n).ToArray();

            array.Print(",").WriteHost("Input");
            expected.Print(",").WriteHost("Wanted");

            //-- Arrange
            var actual = Solution147.SortWithReverseOnly(array);
            actual.Print(",").WriteHost("Output");

            //-- Act
            Assert.AreEqual(expected, actual);
        }
        class Cases147 : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { Enumerable.Range(0, 1).ToArray() };
                yield return new object[] { Enumerable.Range(0, 2).ToArray() };
                yield return new object[] { Enumerable.Range(0, 2).Reverse().ToArray() };
                yield return new object[] { Enumerable.Range(0, 3).Reverse().ToArray() };
                yield return new object[] { Enumerable.Range(0, 4).Shuffle(147).ToArray() };
                yield return new object[] { Enumerable.Range(0, 5).Shuffle(147).ToArray() };
                yield return new object[] { Enumerable.Range(0, 6).Shuffle(147).ToArray() };
                yield return new object[] { Enumerable.Range(0, 7).Shuffle(147).ToArray() };
                yield return new object[] { Enumerable.Range(0, 8).Shuffle(147).ToArray() };
                yield return new object[] { Enumerable.Range(0, 9).Shuffle(147).ToArray() };
                yield return new object[] { Enumerable.Range(0, 10).Shuffle(147).ToArray() };
            }
        }
    }
}