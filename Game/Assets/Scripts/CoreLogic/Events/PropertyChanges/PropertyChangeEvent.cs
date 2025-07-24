namespace TDS.Events
{
    public class PropertyChangeEvent<T,TOwner> : IEvent
    {
        public T OldValue { get; }
        public T NewValue { get; }
        public TOwner Owner { get; }

        public PropertyChangeEvent(T oldValue, T newValue, TOwner owner)
        {
            OldValue = oldValue;
            NewValue = newValue;
            Owner = owner;
        }
    }
}