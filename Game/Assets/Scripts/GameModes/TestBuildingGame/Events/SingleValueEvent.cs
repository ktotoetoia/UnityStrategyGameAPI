using TDS.Events;

namespace BuildingsTestGame
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