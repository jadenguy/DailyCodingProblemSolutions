using System.Collections.Generic;

namespace Common.Repository
{
    public interface IRepository<T, TKey, TValue> : IEnumerable<OrderEntity>
        where T : IEntity<TKey, TValue>
        where TKey : struct
    {
        T Retrieve(TKey key);
    }
}