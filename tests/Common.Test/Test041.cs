// Given an unordered list of flights taken by someone, each represented as (origin, destination) pairs, and a starting airport, compute the person's itinerary. If no such itinerary exists, return null. If there are multiple possible itineraries, return the lexicographically smallest one. All flights must be used in the itinerary.
// For example, given the list of flights {("SFO", "HKO"), ("YYZ", "SFO"), ("YUL", "YYZ"), ("HKO", "ORD")} and starting airport "YUL", you should return the list {"YUL", "YYZ", "SFO", "HKO", "ORD"}.
// Given the list of flights {("SFO", "COM"), ("COM", "YYZ")} and starting airport "COM", you should return null.
// Given the list of flights {("A", "B"), ("A", "C"), ("B", "C"), ("C", "A")} and starting airport "A", you should return the list {"A", "B", "C", "A", "C"} even though {"A", "C", "A", "B", "C"} is also a valid itinerary. However, the first one is lexicographically smaller.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Common.Test
{
    public class Test041
    {

        List<(string, string)[]> array;
        List<string> startingPoint;
        List<string[]> results;
        [SetUp]
        public void Setup()
        {

            array = new List<(string, string)[]>();
            startingPoint = new List<string>();
            results = new List<string[]>();

            array.Add(new (string, string)[] { ("SFO", "HKO"), ("YYZ", "SFO"), ("YUL", "YYZ"), ("HKO", "ORD") });
            startingPoint.Add("YUL");
            results.Add(new string[] { "YUL", "YYZ", "SFO", "HKO", "ORD" });

            array.Add(new (string, string)[] { ("SFO", "COM"), ("COM", "YYZ") });
            startingPoint.Add("COM");
            results.Add(null);

            array.Add(new (string, string)[] { ("A", "B"), ("A", "C"), ("B", "C"), ("C", "A") });
            startingPoint.Add("A");
            results.Add(new string[] { "A", "B", "C", "A", "C" });

        }
        [TearDown]
        public void TearDown() { }
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Problem041(int testCaseIndex)
        {
            //-- Arrange
            var expected = results[testCaseIndex];

            //-- Act
            var itineraries = Solution041.FindItinerary(array[testCaseIndex], startingPoint[testCaseIndex]).ToArray();
            var actual = itineraries.FirstOrDefault();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}