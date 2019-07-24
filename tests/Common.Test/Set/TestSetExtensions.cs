using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Common.Sets.Test
{
    public class TestSetExtensions
    {
        [Test]
        public void TextXor()
        {
            //-- Arrange
            var z = "Z";
            var a = "A";
            var b = "B";
            var expected = new List<string>() { z, b };
            var setA = new List<string>() { z, a };
            var setB = new List<string>() { a, b };

            //-- Act
            var actual = new List<string>(setA.Xor(setB));

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void TestNot()
        {
            //-- Arrange
            var z = "Z";
            var a = "A";
            var b = "B";
            var setA = new List<string>() { z, a };
            var setB = new List<string>() { a, b };
            var expected = new List<string>() { z };

            //-- Act
            var actual = new List<string>(setA.Not(setB));

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void TestAnd()
        {
            //-- Arrange
            var z = "Z";
            var a = "A";
            var b = "B";
            var setA = new List<string>() { z, a };
            var setB = new List<string>() { z, b };
            var expected = new List<string>() { z };

            //-- Act
            var actual = new List<string>(setA.And(setB));

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
        }
        [Test]
        public void TestOr()
        {
            //-- Arrange
            var z = "Z";
            var a = "A";
            var b = "B";
            var setA = new List<string>() { z, z, a };
            var setB = new List<string>() { z, b };
            var expected = new List<string>() { z, a, z, b };

            //-- Act
            var actual = new List<string>(setA.Or(setB));

            //-- Assert
            Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
            //         [Test]
            //         public void ElementIsEquivalent()
            //         {
            //             //-- Arrange
            //             var expected = new string("x");

            //             //-- Act
            //             var actual = new string("x");

            //             //-- Assert
            //             Assert.IsTrue(expected.Equivalent(actual));
            //         }
            //         [Test]
            //         public void ElementExistsInSet()
            //         {
            //             //-- Arrange
            //             var expected = new string("x");

            //             //-- Act
            //             var actual = new List<string>() { "x" };

            //             //-- Assert
            //             Assert.IsTrue(actual.Count() == 1, "wrong number of items");
            //             Assert.IsTrue(expected.Equivalent(actual.FirstOrDefault()), "wrong item");
            //         }
            //         [Test]
            //         public void ElementXorExistsInSet()
            //         {
            //             //-- Arrange
            //             var expected = "x"
            //             var set = new List<string>() { expected };

            //             //-- Act
            //             var array = set;
            //             var actual = set.FirstOrDefault();

            //             //-- Assert
            //             Assert.IsTrue(array.Count() == 1, "wrong number of items");
            //             Assert.IsTrue(expected.Equivalent(actual), "wrong item");
            //         }
            //         [Test]
            //         public void ElementNotDissolvesInSet()
            //         {
            //             //-- Arrange
            //             var expected = new string("x");

            //             //-- Act
            //             var actual = new List<string>(new string[] { "x" });

            //             //-- Assert
            //             Assert.IsTrue(actual.Count() == 1, "wrong number of items");
            //             Assert.IsTrue(expected.Equivalent(actual.First()), "wrong item");
            //         }
            //         [Test]
            //         public void XorElementExistsInSet()
            //         {
            //             //-- Arrange
            //             var expected = "x"

            //             //-- Act
            //             var actual = new List<string>() { expected };

            //             //-- Assert
            //             Assert.IsTrue(actual.Count() == 1, "wrong number of items");
            //             Assert.IsTrue(expected.Equivalent(actual.First()), "wrong item");
            //         }
            //         [Test]
            //         public void SetRenderOutXor()
            //         {
            //             //-- Arrange
            //             var z = "Z";
            //             var aXor = "A"
            //             var expected = new List<string>() { z };

            //             //-- Act
            //             var actual = new List<string>() { z, aXor, aXor };

            //             //-- Assert
            //             Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
            //         }
            //         [Test]
            //         public void TwoSetsContainDifferentCounts()
            //         {
            //             //-- Arrange
            //             var z = "Z";
            //             var expected = new List<string>() { z };

            //             //-- Act
            //             var actual = new List<string>() { z, z, aXor, aXor };

            //             //-- Assert
            //             Assert.IsFalse(actual.SetEquivalent(expected), "Sets differ");
            //         }
            //         [Test]
            //         public void SetContainsTwoIdenticalElements()
            //         {
            //             //-- Arrange
            //             var z = "Z";
            //             var expected = new List<string>() { z, z };

            //             //-- Act
            //             var actual = new List<string>() { z, z, aXor, aXor };

            //             //-- Assert
            //             Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
            //         }
            //         [Test]
            //         public void SetRenderOutNot()
            //         {
            //             //-- Arrange
            //             var z = "Z";
            //             var a = "A";
            //             var expected = new List<string>() { z };

            //             //-- Act
            //             var actual = new List<string>() { z, a, aNot };

            //             //-- Assert
            //             Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
            //         }
            //         [Test]
            //         public void SetRenderOutNotWithXor()
            //         {
            //             //-- Arrange
            //             var z = "Z";
            //             var a = "A";
            //             var expected = new List<string>() { z };

            //             //-- Act
            //             var actual = new List<string>() { z, a, aNot, aXor, aXor };

            //             //-- Assert
            //             Assert.IsTrue(actual.SetEquivalent(expected), "Sets differ");
            //         }
        }
    }
}