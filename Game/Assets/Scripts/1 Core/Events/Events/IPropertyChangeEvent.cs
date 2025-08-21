namespace TDS.Events
{
    public interface IPropertyChangeEvent : IEvent
    {
        object OldValue { get; }
        object NewValue { get; }
        object Owner { get; }
    }
}