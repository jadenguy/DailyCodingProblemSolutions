// functions = []
// for i in range(10):
//     functions.append(lambda : i)

// for f in functions:
//     print(f())

using NUnit.Framework;

namespace Common.Test
{
    public class Test091
    {
        // [SetUp] public void Setup() { }
        // [TearDown] public void TearDown(){}
        [Test]
        public void Problem091()
        {
            // functions = []
            // for i in range(10):
            //     functions.append(lambda x=i: x) //
            // // i = 9 at this point, but if we set the lambda to return a new scoped variable x, it will retain that scope per row in functions
            // for f in functions:
            //     print(f())
            Assert.Pass();
        }
    }
}