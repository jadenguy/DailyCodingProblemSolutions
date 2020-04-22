// Soundex <https://nam04.safelinks.protection.outlook.com/?url=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FSoundex&data=02%7C01%7Cainostroza%40attentigroup.com%7Caa0c035f1cef4360ea8108d7ca8e971c%7Ccb91552f7d2a449d95b84638c423f880%7C1%7C0%7C637200586089624692&sdata=JBKAcZlqnhme%2BufVdy6VtnUbJSAC%2Bmt%2FVlROAyfCquc%3D&reserved=0>  is an algorithm used to categorize phonetically, such that two names that sound alike but are spelled differently have the same representation.
// Soundex maps every name to a string consisting of one letter and three numbers, like M460.
// One version of the algorithm is as follows:
// 1.	Remove consecutive consonants with the same sound (for example, change ck -> c).
// 2.	Keep the first letter. The remaining steps only apply to the rest of the string.
// 3.	Remove all vowels, including y, w, and h.
// 4.	Replace all consonants with the following digits:
// 	*	b, f, p, v ? 1
// 	*	c, g, j, k, q, s, x, z ? 2
// 	*	d, t ? 3
// 	*	l ? 4
// 	*	m, n ? 5
// 	*	r ? 6
// 5.	If you don't have three numbers yet, append zeros until you do. Keep the first three numbers.
// Using this scheme, Jackson and Jaxen both map to J250.
using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Test
{
    public class Test349
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        //[Test]
        public void Problem349()
        {
            //-- Assert

            //-- Arrange

            //-- Act
            Assert.Pass();
        }
    }
}
