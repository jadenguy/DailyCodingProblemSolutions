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
            var expected = new SetElement<string>("x");

            //-- Act
            var actual = new SetElement<string>("x");

            //-- Assert
            Assert.IsTrue(expected.Equivalent(actual));
        }
        [Test]
        public void ElementExistsInSet()
        {
            //-- Arrange
            var expected = new SetElement<string>("x");

            //-- Act
            var actual = new Set<string>() { "x" };

            //-- Assert
            Assert.IsTrue(actual.Count() == 1, "wrong number of items");
            Assert.IsTrue(expected.Equivalent(actual.FirstOrDefault()), "wrong item");
        }
        [Test]
        public void ElementXorExistsInSet()
        {
            //-- Arrange
            var expected = new SetElement<string>("x", false, true);
            var set = new Set<string>() { expected };

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
            var expected = new SetElement<string>("x");

            //-- Act
            var actual = new Set<string>(new string[] { "x" });

            //-- Assert
            Assert.IsTrue(actual.Count() == 1, "wrong number of items");
            Assert.IsTrue(expected.Equivalent(actual.First()), "wrong item");
        }
        [Test]
        public void XorElementExistsInSet()
        {
            //-- Arrange
            var expected = new SetElement<string>("x", false, true);

            //-- Act
            var actual = new Set<string>() { expected };

            //-- Assert
            Assert.IsTrue(actual.Count() == 1, "wrong number of items");
            Assert.IsTrue(expected.Equivalent(actual.First()), "wrong item");
        }
        [Test]
        public void SetRenderOutXor()
        {
            //-- Arrange
            var z = new SetElement<string>("Z", false, false);
            var aXor = new SetElement<string>("A", false, true);
            var expected = new List<SetElement<string>>() { z };

            //-- Act
            var actual = new Set<string>() { z, aXor, aXor };

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void TwoSetsContainDifferentCounts()
        {
            //-- Arrange
            var z = new SetElement<string>("Z", false, false);
            var aXor = new SetElement<string>("A", false, true);
            var expected = new Set<string>() { z };

            //-- Act
            var actual = new Set<string>() { z, z, aXor, aXor };

            //-- Assert
            Assert.IsFalse(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void SetContainsTwoIdenticalElements()
        {
            //-- Arrange
            var z = new SetElement<string>("Z", false, false);
            var aXor = new SetElement<string>("A", false, true);
            var expected = new List<SetElement<string>>() { z, z };

            //-- Act
            var actual = new Set<string>() { z, z, aXor, aXor };

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void SetRenderOutNot()
        {
            //-- Arrange
            var z = new SetElement<string>("Z", false, false);
            var a = new SetElement<string>("A", false, false);
            var aNot = new SetElement<string>("A", true, false);
            var expected = new List<SetElement<string>>() { z };

            //-- Act
            var actual = new Set<string>() { z, a, aNot };

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void SetRenderOutNotWithXor()
        {
            //-- Arrange
            var z = new SetElement<string>("Z", false, false);
            var a = new SetElement<string>("A", false, false);
            var aNot = new SetElement<string>("A", true, false);
            var aXor = new SetElement<string>("A", false, true);
            var expected = new List<SetElement<string>>() { z };

            //-- Act
            var actual = new Set<string>() { z, a, aNot, aXor, aXor };

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void TestJoinXor()
        {
            //-- Arrange
            var z = new SetElement<string>("Z", false, false);
            var a = new SetElement<string>("A", false, false);
            var b = new SetElement<string>("B", false, false);
            var aNot = new SetElement<string>("A", true, false);
            var aXor = new SetElement<string>("A", false, true);
            var bXor = new SetElement<string>("B", false, true);
            var expected = new List<SetElement<string>>() { z, bXor };
            var setA = new Set<string>() { z, aXor };
            var setB = new Set<string>() { a, b };

            //-- Act
            var actual = new Set<string>(setA.Xor(setB));

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void TestNot()
        {
            //-- Arrange
            var z = new SetElement<string>("Z", false, false);
            var a = new SetElement<string>("A", false, false);
            var b = new SetElement<string>("B", false, false);
            var aNot = new SetElement<string>("A", true, false);
            var aXor = new SetElement<string>("A", false, true);
            var setA = new Set<string>() { z, a };
            var setB = new Set<string>() { a, b };
            var expected = new List<SetElement<string>>() { z };

            //-- Act
            var actual = new Set<string>(setA.Not(setB));

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void TestAnd()
        {
            //-- Arrange
            var z = new SetElement<string>("Z", false, false);
            var a = new SetElement<string>("A", false, false);
            var b = new SetElement<string>("B", false, false);
            var aNot = new SetElement<string>("A", true, false);
            var aXor = new SetElement<string>("A", false, true);
            var setA = new Set<string>() { z, z, a };
            var setB = new Set<string>() { z
            , b };
            var expected = new List<SetElement<string>>() { z };

            //-- Act
            var actual = new Set<string>(setA.And(setB));

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void TestOr()
        {
            //-- Arrange
            var z = new SetElement<string>("Z", false, false);
            var a = new SetElement<string>("A", false, false);
            var b = new SetElement<string>("B", false, false);
            var aNot = new SetElement<string>("A", true, false);
            var aXor = new SetElement<string>("A", false, true);
            var setA = new Set<string>() { z, z, a };
            var setB = new Set<string>() { z
            , b };
            var expected = new List<SetElement<string>>() { z, a, z, b };

            //-- Act
            var actual = new Set<string>(setA.Or(setB));

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
    }
}