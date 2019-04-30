// You run an e-commerce website and want to record the last N order ids in a log. Implement a data structure to accomplish this, with the following API:
// •	record(order_id): adds the order_id to the log
// •	get_last(i): gets the ith last element from the log. i is guaranteed to be smaller than or equal to N.
// You should be as efficient with time and space as possible.

using System.Collections.Generic;
using System.Linq;
using Common.Repository;
using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class Test16
    {
        public int[] array;
        public OrderRepository repository;
        [SetUp]
        public void SetUp()
        {
            array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }
        [Test]
        public void AddToOrderRepository()
        {
            repository = new OrderListRepository();
            foreach (var item in array)
            {
                //-- Arrange
                var expected = item;
                repository.Record(new OrderEntity(item));

                //-- Act
                var actual = repository.Last().Id;
                //-- Assert

                Assert.AreEqual(expected, actual);
            }
            Assert.AreEqual(array, repository.Select(o => o.Id).ToArray());
        }
        [Test]
        [TestCase(1, 9)]
        [TestCase(2, 8)]
        public void Solution16(int i, int result)
        {
            //-- Arrange
            var expected = result;
            repository = new OrderListRepository();
            foreach (int item in array) { repository.Record(new OrderEntity(item)); }

            //-- Act
            var actual = repository.GetLast(i).Id;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
