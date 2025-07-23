namespace TDS.Commands
{
    public interface IEventBus
    {
        void Subscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent;
        void Unsubscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent;

        void Publish<TEvent>(TEvent evt) where TEvent : IEvent;
    }
}