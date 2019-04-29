using System;
using System.Collections;
using System.Collections.Generic;

namespace Common.Repository
{
    public abstract class OrderRepository : IEnumerable<OrderEntity>
    {
        public OrderRepository() { }
        public abstract OrderEntity this[int orderNumber] { get; set; }
        public abstract IEnumerator<OrderEntity> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        public abstract void Record(OrderEntity order);
        public abstract OrderEntity GetLast(int rowCount);
    }
}