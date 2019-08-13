namespace Common.Repository
{
    interface IEntity<TId, TValue> where TId : struct
    {
        TId Id { get; set; }
        TValue Value { get; set; }
    }
}