namespace TDS.Events
{
    public interface ICallPropertyChange<T>
    {
        T Value { get; set; }
    }

    public interface ICallPropertyChange<T, out TOwnerType> : ICallPropertyChange<T>
    {
        TOwnerType Owner { get; }
    }
}