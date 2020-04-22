// The �active time� of a courier is the time between the pickup and dropoff of a delivery. Given a set of data formatted like the following:
// (delivery id, timestamp, pickup/dropoff)
// Calculate the total active time in seconds. A courier can pick up multiple orders before dropping them off. The timestamp is in unix epoch seconds.
// For example, if the input is the following:
// (1, 1573280047, 'pickup')
// (1, 1570320725, 'dropoff')
// (2, 1570321092, 'pickup')
// (3, 1570321212, 'pickup')
// (3, 1570322352, 'dropoff')
// (2, 1570323012, 'dropoff')
using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Test
{
    public class Test370
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        //[Test]
        public void Problem370()
        {
            //-- Assert

            //-- Arrange

            //-- Act
            Assert.Pass();
        }
    }
}
