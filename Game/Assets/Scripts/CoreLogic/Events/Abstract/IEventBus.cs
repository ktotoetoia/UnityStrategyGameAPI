namespace TDS.Events
{
    public interface IEventBus
    {
        void Subscribe(IEventHandler handler);
        void Unsubscribe(IEventHandler handler);
        void Publish(IEvent evt);
    }
}