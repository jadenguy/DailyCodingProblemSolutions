// A Boolean formula can be said to be satisfiable if there is a way to assign truth values to each variable such that the entire formula evaluates to true.
// For example, suppose we have the following formula, where the symbol ¬ is used to denote negation:
// (¬c OR b) AND (b OR c) AND (¬b OR c) AND (¬c OR ¬a)
// One way to satisfy this formula would be to let a = False, b = True, and c = True.
// This type of formula, with AND statements joining tuples containing exactly one OR, is known as 2-CNF.
using System;
using System.Linq;
using NUnit.Framework;
using Common.Extensions;

namespace Common.Test
{
    public class Test330
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown() { }
        //[Test]
        public void Problem330()
        {
            //-- Assert

            //-- Arrange

            //-- Act
            Assert.Pass();
        }
    }
}
