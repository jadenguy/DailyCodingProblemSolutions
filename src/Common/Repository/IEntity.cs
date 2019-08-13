namespace Common.Repository
{
    public interface IEntity<TKey, TValue> where TKey : struct
    {
        TKey Id { get; set; }
        TValue Value { get; set; }
    }
}