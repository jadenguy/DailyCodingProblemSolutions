using NUnit.Framework;

namespace Common.Test
{
    public class Test040
    {
        // [SetUp]
        // public void Setup() { }
        // [TearDown]
        // public void TearDown() { }
        [Test]
        public void Problem040(int n, int results)
        {
            //-- Arrange
            var expected = results;

            //-- Act
            var actual = Solution040.DoThis();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}