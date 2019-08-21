// Implement an LRU (Least Recently Used) cache. It should be able to be initialized with a cache size n, and contain the following methods:
// •	set(key, value): sets key to value. If there are already n items in the cache and we are adding a new item, then it should also remove the least recently used item.
// •	get(key): gets the value at key. If no such key exists, return null.
// Each operation should run in O(1) time.


using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test052
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem052IntStringGet()
        {
            //-- Arrange
            var expected = "x";
            var key = 1000;
            const int Capacity = 10;
            var cache = new LruCache<int, string>(Capacity);

            //-- Act
            cache.Set(key, expected);
            var actual = cache.Get(key);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem052StringStringGetOutOfBounds()
        {
            //-- Arrange
            var wanted = "x";
            string expected = null;
            var key = "1000";
            const int Capacity = 10;
            var cache = new LruCache<string, string>(Capacity);

            //-- Act
            cache.Set(key, wanted);
            for (int i = 0; i < Capacity; i++)
            {
                cache.Set(i.ToString(), i.ToString());
                System.Diagnostics.Debug.WriteLine(cache.Get(i.ToString()));
            }
            var actual = cache.Get(key);

            // //-- Assert
            Assert.AreNotEqual(wanted, actual);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem052StringStringGetEmpty()
        {
            //-- Arrange
            var wanted = "x";
            string expected = null;
            var key = "";
            const int Capacity = 10;
            var cache = new LruCache<string, string>(Capacity);

            //-- Act
            var actual = cache.Get(key);

            // //-- Assert
            Assert.AreNotEqual(wanted, actual);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem052IntIntGetEmpty()
        {
            //-- Arrange
            var wanted = 10;
            var expected = 0;
            var key = 0;
            const int Capacity = 10;
            var cache = new LruCache<int, int>(Capacity);

            //-- Act
            var actual = cache.Get(key);

            // //-- Assert
            Assert.AreNotEqual(wanted, actual);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem052IntStringGetOutOfBounds()
        {
            //-- Arrange
            var wanted = "x";
            string expected = null;
            var key = 1000;
            const int Capacity = 10;
            var cache = new LruCache<int, string>(Capacity);

            //-- Act
            cache.Set(key, wanted);
            for (int i = 0; i < Capacity; i++)
            {
                cache.Set(i, i.ToString());
                System.Diagnostics.Debug.WriteLine(cache.Get(i));
            }
            var actual = cache.Get(key);

            // //-- Assert
            Assert.AreNotEqual(wanted, actual);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem052IntStringWriteToZero()
        {
            //-- Arrange
            var wanted = "x";
            string expected = wanted;
            var key = 1000;
            const int Capacity = 10;
            var cache = new LruCache<int, string>(Capacity);

            //-- Act
            cache.Set(key, wanted);
            for (int i = 0; i < Capacity; i++)
            {
                cache.Set(0, i.ToString());
                System.Diagnostics.Debug.WriteLine(cache.Get(0));
            }
            var actual = cache.Get(key);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Problem052IntIntGet()
        {
            //-- Arrange
            var expected = 2000;
            var key = 1000;
            const int Capacity = 10;
            var cache = new LruCache<int, int>(Capacity);

            //-- Act
            cache.Set(key, expected);
            var actual = cache.Get(key);

            // //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}