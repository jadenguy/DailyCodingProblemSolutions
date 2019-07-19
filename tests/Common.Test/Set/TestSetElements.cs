using System.Linq;
using NUnit.Framework;

namespace Common.Sets.Test
{

    public class TestSetElements
    {
        [Test]
        public void test()
        {
            //-- Arrange
            var expected = new SetElement("z"); ;
            var set1 = new Set(new string[] { "x", "y", "y", "y", "y", "y" });
            var set2 = new Set(new string[] { "x", "y", "y", "y", "y", "y", "z" });

            //-- Act
            var actual = set2.Not(set1).Contents.First();

            //-- Assert
            Assert.IsTrue(expected.IsSame(actual));
        }
    }
}