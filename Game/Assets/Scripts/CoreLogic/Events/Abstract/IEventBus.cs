namespace TDS.Events
{
    public interface IEventBus : IEventPublisher, IEventSubscriber
    {
        
    }

    public interface IEventPublisher
    {
        void Publish(IEvent evt);
    }

    public interface IEventSubscriber
    {
        void Subscribe(IEventHandler handler);
        void Unsubscribe(IEventHandler handler);
    }
}