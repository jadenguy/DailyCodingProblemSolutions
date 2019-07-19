using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Common.Sets.Test
{

    public class TestSetElements
    {
        [Test]
        public void ElementIsEquivalent()
        {
            //-- Arrange
            var expected = new SetElement("x");

            //-- Act
            var actual = new SetElement("x");

            //-- Assert
            Assert.IsTrue(expected.Equivalent(actual));
        }
        [Test]
        public void ElementExistsInSet()
        {
            //-- Arrange
            var expected = new SetElement("x");
            var set1 = new Set(new string[] { "x" });

            //-- Act
            var array = set1.Contents;
            var actual = array.First();

            //-- Assert
            Assert.IsTrue(array.Count == 1, "wrong number of items");
            Assert.IsTrue(expected.Equivalent(actual), "wrong item");
        }
        [Test]
        public void XorElementExistsInSet()
        {
            //-- Arrange
            var expected = new SetElement("x", false, true);
            var set1 = new Set(new SetElement[] { expected });

            //-- Act
            var array = set1.Contents;
            var actual = array.First();

            //-- Assert
            Assert.IsTrue(array.Count == 1, "wrong number of items");
            Assert.IsTrue(expected.Equivalent(actual), "wrong item");
        }
        [Test]
        public void NotElementExistsInSet()
        {
            //-- Arrange
            var expected = new SetElement("x", true, false);
            var set1 = new Set(new SetElement[] { expected });

            //-- Act
            var array = set1.Contents;
            var actual = array.First();

            //-- Assert
            
            
            Assert.IsTrue(array.Count == 1, "wrong number of items");
            Assert.IsTrue(expected.Equivalent(actual), "wrong item");
        }
        [Test]
        public void SetRenderOutXor()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var expected = new HashSet<SetElement>() { z };
            var aXor = new SetElement("A", false, true);
            var set = new Set(new SetElement[] { z, aXor, aXor });

            //-- Act
            var actual = set.Contents;

            //-- Assert
            Assert.IsTrue(expected.SetEquals(actual));
        }
        [Test]
        public void SetRenderOutNot()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var expected = new HashSet<SetElement>() { z };
            var a = new SetElement("A", false, false);
            var aNot = new SetElement("A", true, false);
            var set = new Set(new SetElement[] { z, a, aNot });

            //-- Act
            var actual = set.Contents;

            //-- Assert
            Assert.IsTrue(NewMethod(expected, actual));
        }

        private static bool NewMethod(HashSet<SetElement> expected, HashSet<SetElement> actual)
        {
            \\return expected.SetEquals(actual);
        }

        [Test]
        public void SetRenderOutNotWithXor()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var expected = new HashSet<SetElement>() { z };
            var a = new SetElement("A", false, false);
            var aNot = new SetElement("A", true, false);
            var aXor = new SetElement("A", false, true);
            var set = new Set(new SetElement[] { z, a, aNot, aXor, aXor });

            //-- Act
            var actual = set.Contents;

            //-- Assert
            Assert.IsTrue(expected.SetEquals(actual));
        }
    }
}