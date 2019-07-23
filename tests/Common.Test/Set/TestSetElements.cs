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

            //-- Act
            var actual = new Set() { "x" };

            //-- Assert
            Assert.IsTrue(actual.Count() == 1, "wrong number of items");
            Assert.IsTrue(expected.Equivalent(actual.FirstOrDefault()), "wrong item");
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

            //-- Act
            var actual = new Set(new string[] { "x" });

            //-- Assert
            Assert.IsTrue(actual.Count() == 1, "wrong number of items");
            Assert.IsTrue(expected.Equivalent(actual.First()), "wrong item");
        }
        [Test]
        public void XorElementExistsInSet()
        {
            //-- Arrange
            var expected = new SetElement("x", false, true);

            //-- Act
            var actual = new Set() { expected };

            //-- Assert
            Assert.IsTrue(actual.Count() == 1, "wrong number of items");
            Assert.IsTrue(expected.Equivalent(actual.First()), "wrong item");
        }
        [Test]
        public void SetRenderOutXor()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var aXor = new SetElement("A", false, true);
            var expected = new List<SetElement>() { z };

            //-- Act
            var actual = new Set() { z, aXor, aXor };

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void TwoSetsContainDifferentCounts()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var aXor = new SetElement("A", false, true);
            var expected = new Set() { z };

            //-- Act
            var actual = new Set() { z, z, aXor, aXor };

            //-- Assert
            Assert.IsFalse(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void SetContainsTwoIdenticalElements()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var aXor = new SetElement("A", false, true);
            var expected = new List<SetElement>() { z, z };

            //-- Act
            var actual = new Set() { z, z, aXor, aXor };

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void SetRenderOutNot()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var a = new SetElement("A", false, false);
            var aNot = new SetElement("A", true, false);
            var expected = new List<SetElement>() { z };

            //-- Act
            var actual = new Set() { z, a, aNot };

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void SetRenderOutNotWithXor()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var a = new SetElement("A", false, false);
            var aNot = new SetElement("A", true, false);
            var aXor = new SetElement("A", false, true);
            var expected = new List<SetElement>() { z };

            //-- Act
            var actual = new Set() { z, a, aNot, aXor, aXor };

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void TestJoinXor()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var a = new SetElement("A", false, false);
            var b = new SetElement("B", false, false);
            var aNot = new SetElement("A", true, false);
            var aXor = new SetElement("A", false, true);
            var bXor = new SetElement("B", false, true);
            var expected = new List<SetElement>() { z, bXor };
            var setA = new Set() { z, aXor };
            var setB = new Set() { a, b };

            //-- Act
            var actual = new Set(setA.Xor(setB));

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void TestNot()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var a = new SetElement("A", false, false);
            var b = new SetElement("B", false, false);
            var aNot = new SetElement("A", true, false);
            var aXor = new SetElement("A", false, true);
            var setA = new Set() { z, a };
            var setB = new Set() { a, b };
            var expected = new List<SetElement>() { z };

            //-- Act
            var actual = new Set(setA.Not(setB));

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void TestAnd()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var a = new SetElement("A", false, false);
            var b = new SetElement("B", false, false);
            var aNot = new SetElement("A", true, false);
            var aXor = new SetElement("A", false, true);
            var setA = new Set() { z, z, a };
            var setB = new Set() { z
            , b };
            var expected = new List<SetElement>() { z };

            //-- Act
            var actual = new Set(setA.And(setB));

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void TestOr()
        {
            //-- Arrange
            var z = new SetElement("Z", false, false);
            var a = new SetElement("A", false, false);
            var b = new SetElement("B", false, false);
            var aNot = new SetElement("A", true, false);
            var aXor = new SetElement("A", false, true);
            var setA = new Set() { z, z, a };
            var setB = new Set() { z
            , b };
            var expected = new List<SetElement>() { z, a, z, b };

            //-- Act
            var actual = new Set(setA.Or(setB));

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
    }
}