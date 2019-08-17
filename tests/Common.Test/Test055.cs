// Implement a URL shortener with the following methods:
// •	shorten(url), which shortens the url into a six-character alphanumeric string, such as zLg6wl.
// •	restore(short), which expands the shortened string into the original url. If no such shortened string exists, return null.
// Hint: What if we enter the same URL twice?



using System;
using Common.Url;
using NUnit.Framework;

namespace Common.Test
{
    public class Test055Encoding
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        [Test]
        public void Problem055Encode()
        {
            //-- Arrange
            Random rand = new Random();
            var urlShortener = new Shortener(rand.Next());
            const int urlCount = 100;
            string[] urls = new string[urlCount];
            string[] shortenedUrls = new string[urlCount];

            //-- Act
            for (int i = 0; i < urlCount; i++)
            {
                urls[i] = "www.Site" + rand.Next().ToString("X4") + ".com";
                shortenedUrls[i] = urlShortener.Shorten(urls[i]);
            }

            //-- Assert
            for (int n = 0; n < urlCount * 2; n++)
            {
                var i = n % urlCount;
                var expectedUrl = urls[i];
                var actual = shortenedUrls[i];
                Assert.AreEqual(expectedUrl, actual, "something went wrong");
            }
        }
        [Test]
        public void Problem055Decode()
        {
            //-- Arrange
            Random rand = new Random();
            var urlShortener = new Shortener(rand.Next());
            const int urlCount = 100;
            string[] urls = new string[urlCount];
            string[] shortenedUrls = new string[urlCount];

            //-- Act
            for (int i = 0; i < urlCount; i++)
            {
                urls[i] = "www.Site" + rand.Next().ToString("X4") + ".com";
                shortenedUrls[i] = urlShortener.Shorten(urls[i]);
            }

            //-- Assert
            for (int n = 0; n < urlCount * 2; n++)
            {
                var i = n % urlCount;
                var expectedUrl = urls[i];
                var actual = urlShortener.Restore(shortenedUrls[i]);
                Assert.AreEqual(expectedUrl, actual, "something went wrong");
            }
        }
    }
}