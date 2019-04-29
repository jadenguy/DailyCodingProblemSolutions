namespace Common.Repository
{
    public class OrderEntity : IEntity<int, Order>
    {
        public OrderEntity(int id) => Id = id;
        public int Id { get; set; }
        public Order Order { get; set; }
    }
}