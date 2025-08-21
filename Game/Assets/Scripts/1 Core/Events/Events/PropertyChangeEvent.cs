namespace TDS.Events
{
    public class PropertyChangeEvent<T, TOwner> : IPropertyChangeEvent
    {
        public T OldValue { get; }
        public T NewValue { get; }
        public TOwner Owner { get; }

        object IPropertyChangeEvent.OldValue => OldValue;
        object IPropertyChangeEvent.NewValue => NewValue;
        object IPropertyChangeEvent.Owner => Owner;

        public PropertyChangeEvent(T oldValue, T newValue, TOwner owner)
        {
            OldValue = oldValue;
            NewValue = newValue;
            Owner = owner;
        }
    }
}