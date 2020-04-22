$start = @"

using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Test
{
    public class Test
"@
$middle = @"

    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        //[Test]
        public void Problem
"@
$end = @"
()
        {
            //-- Assert

            //-- Arrange

            //-- Act
            Assert.Pass();
        }
    }
}
"@