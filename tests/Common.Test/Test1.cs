using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class Test1
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new int[] {10, 15, 3, 7 }, 17,true)]
        public void Problem1(int[] list, int contains, bool answer)
        {
            //-- Arrange
            var expected = answer;

            //-- Act
            var actual = Common.Solution1.PairSumsContain(list,contains);

            //-- Assert
            Assert.AreEqual(actual, expected);

        }
    }
}