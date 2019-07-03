// An XOR linked list is a more memory efficient doubly linked list. Instead of each node holding next and prev fields, it holds a field named both, which is an XOR of the next node and the previous node. Implement an XOR linked list; it has an add(element) which adds the element to the end, and a get(index) which returns the node at index.
// If using a language that has no pointers (such as Python), you can assume you have access to get_pointer and dereference_pointer functions that converts between nodes and memory addresses.


using System;
using System.Linq;
using Common.Node;
using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test6
    {

        [Test]
        public void Problem6()
        {
            //-- Arrange
            var memory = new XorLinkedListMemoryDictionary(new string[] { "X", "Y", "Z" });
            var expected = 6;

            //-- Act
            memory.Add("A");
            memory.Add("B");
            memory.Add("C");
            var actual = memory.Count();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}