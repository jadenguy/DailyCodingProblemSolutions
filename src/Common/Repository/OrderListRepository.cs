using System;
using System.Collections.Generic;

namespace Common.Repository
{
    public class OrderListRepository : OrderRepository
    {
        private List<OrderEntity> orderList = new List<OrderEntity>();

        public override OrderEntity this[int orderNumber] { get => orderList[orderNumber]; set => orderList[orderNumber] = value; }

        public override IEnumerator<OrderEntity> GetEnumerator() => orderList.GetEnumerator();

        public override IEnumerable<OrderEntity> GetLast(int rowCount) => orderList.GetRange(orderList.Count - rowCount, rowCount);

        public override void Record(OrderEntity orderEntity) => orderList.Add(orderEntity);

    }
}