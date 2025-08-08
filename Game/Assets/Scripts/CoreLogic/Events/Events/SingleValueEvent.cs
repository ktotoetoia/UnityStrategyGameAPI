namespace TDS.Events
{
    public class SingleValueEvent<T> : IEvent
    {
        public T Value { get; }

        public SingleValueEvent(T value)
        {
            Value = value;
        }
    }
}