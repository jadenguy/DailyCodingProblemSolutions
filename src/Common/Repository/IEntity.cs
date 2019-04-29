namespace Common.Repository
{
    interface IEntity<T, V> where T : struct
    {
        T Id { get; set; }
        V Order { get; set; }
    }
}