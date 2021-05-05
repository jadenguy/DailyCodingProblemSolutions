// Given a 2-D matrix representing an image, a location of a pixel in the screen and a color C, replace the color of the given pixel and all adjacent same colored pixels with C.
// For example, given the following matrix, and location pixel of (2, 2), and 'G' for green:
// B B W
// W W W
// W W W
// B B B
// Becomes
// B B G
// G G G
// G G G
// B B B

using NUnit.Framework;
using System.Collections;

namespace Common.Test
{
    public class Test151
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        [TestCaseSource(typeof(Cases151))]
        public void Problem151(Solution151.Color[,] colors, int x, int y, Solution151.Color[,] colorsAfter)
        {
            //-- Assert
            var expected = colorsAfter;

            //-- Arrange
            var actual = Solution151.FloodColor(colors, x, y, g);

            //-- Act
            Assert.AreEqual(expected, actual);
        }
        public class Cases151 : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                // Simple Test
                var colors = new[,] { { b, w } };
                var colorsAfter = new[,] { { b, g } };
                int x = 0;
                int y = 1;
                yield return new object[] { colors, x, y, colorsAfter };

                // Simple Test 2
                colors = new[,] {
                    { b, w }
                };
                colorsAfter = new[,] {
                    { g, w }
                };
                x = 0;
                y = 0;
                yield return new object[] { colors, x, y, colorsAfter };

                // given test
                colors = new[,] {
                    {b,b,w},
                    {w,w,w},
                    {w,w,w},
                    {b,b,b} };
                colorsAfter = new[,] {
                    {b,b,g},
                    {g,g,g},
                    {g,g,g},
                    {b,b,b} };
                x = 2;
                y = 2;
                yield return new object[] { colors, x, y, colorsAfter };
            }
        }
        const Solution151.Color w = Solution151.Color.White;
        const Solution151.Color b = Solution151.Color.Black;
        const Solution151.Color g = Solution151.Color.Green;
    }
}
