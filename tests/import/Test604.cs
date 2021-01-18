// Soundex <https://nam04.safelinks.protection.outlook.com/?url=https%3A%2F%2Fen.wikipedia.org%2Fwiki%2FSoundex&data=04%7C01%7Cainostroza%40attentigroup.com%7C022e0113fedf4fcda82d08d89a1018b9%7Ccb91552f7d2a449d95b84638c423f880%7C1%7C0%7C637428741219644715%7CUnknown%7CTWFpbGZsb3d8eyJWIjoiMC4wLjAwMDAiLCJQIjoiV2luMzIiLCJBTiI6Ik1haWwiLCJXVCI6Mn0%3D%7C1000&sdata=0lixWfMRF1n%2BGTezGo4Lo6gzwVUrh9eOtj2VxGH%2FeWk%3D&reserved=0>  is an algorithm used to categorize phonetically, such that two names that sound alike but are spelled differently have the same representation.
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
    public class Test604
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        //[Test]
        public void Problem604()
        {
            //-- Assert

            //-- Arrange

            //-- Act
            Assert.Pass();
        }
    }
}
