using System.Collections.Generic;
using Common;
using NUnit.Framework;

namespace Common.Tests
{
    public class Test3
    {
        [SetUp]
        public void Setup()
        {
            Node root = new Node();
        }
        [Test]
        [TestCase("left.left")]
        public void Problem3(string answer)
        {
            //-- Arrange
            var expected = answer;
            string actual = string.Empty;

            //-- Act

            // actual = Solution3.SerializeNodes(root);


            //-- Assert
            Assert.AreEqual(actual, expected);
        }
    }
}