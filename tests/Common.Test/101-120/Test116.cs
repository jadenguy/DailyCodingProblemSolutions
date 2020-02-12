// Generate a finite, but an arbitrarily large binary tree quickly in O(1).
// That is, generate() should return a tree whose size is unbounded but finite.

using Common.Extensions;
using NUnit.Framework;

namespace Common.Test
{
    public class Test116
    {
        private const int V = 10;

        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem116()
        {
            for (int i = 0; i < V; i++)
            {
                var actual = Solution116.Generate(i);
                Assert.IsFalse(actual.KnownLeft);
                actual.Print().WriteHost();
                Assert.IsTrue(actual.KnownLeft);
            }
        }
    }
}
