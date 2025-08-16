namespace TDS.Events
{
    public interface IPropertyChangeEvent
    {
        object OldValue { get; }
        object NewValue { get; }
        object Owner { get; }
    }
}