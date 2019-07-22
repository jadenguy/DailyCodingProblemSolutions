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
            var set = new Set() { "x" };

            //-- Act
            var array = set;
            var actual = set.FirstOrDefault();

            //-- Assert
            Assert.IsTrue(array.Count() == 1, "wrong number of items");
            Assert.IsTrue(expected.Equivalent(actual), "wrong item");
        }
        [Test]
        public void ElementXorExistsInSet()
        {
            //-- Arrange
            var expected = new SetElement("x", false, true);
            var set = new Set() { expected };

            //-- Act
            var array = set;
            var actual = set.FirstOrDefault();

            //-- Assert
            Assert.IsTrue(array.Count() == 1, "wrong number of items");
            Assert.IsTrue(expected.Equivalent(actual), "wrong item");
        }
        [Test]
        public void ElementNotDissolvesInSet()
        {
            //-- Arrange
            var expected = new SetElement("x");
            var set = new Set(new string[] { "x" });

            //-- Act
            var array = set;
            var actual = set.FirstOrDefault();

            //-- Assert
            Assert.IsTrue(array.Count() == 1, "wrong number of items");
            Assert.IsTrue(expected.Equivalent(actual), "wrong item");
        }
        [Test]
        public void XorElementExistsInSet()
        {
            //-- Arrange
            var expected = new SetElement("x", false, true);
            var set = new Set() { expected };

            //-- Act
            var array = set;
            var actual = array.First();

            //-- Assert
            Assert.IsTrue(array.Count() == 1, "wrong number of items");
            Assert.IsTrue(expected.Equivalent(actual), "wrong item");
        }
        [Test]
        public void SetRenderOutXor()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var expected = new List<SetElement>() { z };
            var aXor = new SetElement("A", false, true);
            var set = new Set() { z, aXor, aXor };

            //-- Act
            var actual = set;

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void SetRenderOutNot()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var expected = new List<SetElement>() { z };
            var a = new SetElement("A", false, false);
            var aNot = new SetElement("A", true, false);
            var set = new Set() { z, a, aNot };

            //-- Act
            var actual = set;

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void SetRenderOutNotWithXor()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var expected = new List<SetElement>() { z };
            var a = new SetElement("A", false, false);
            var aNot = new SetElement("A", true, false);
            var aXor = new SetElement("A", false, true);
            var set = new Set() { z, a, aNot, aXor, aXor };

            //-- Act
            var actual = set;

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
    }
}