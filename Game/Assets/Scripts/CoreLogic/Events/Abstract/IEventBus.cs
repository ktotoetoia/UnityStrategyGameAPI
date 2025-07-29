using TDS.Handlers;

namespace TDS.Events
{
    public interface IEventBus: IEventPublisher, IEventSubscriber
    {
        
    }

    public interface IEventPublisher
    {
        void Publish<TEvent>(TEvent evt) where TEvent : IEvent;
    }

    public interface IEventSubscriber
    {
        void Subscribe<TEvent>(IHandler<TEvent> handler) where TEvent : IEvent;
        void Unsubscribe<TEvent>(IHandler<TEvent> handler) where TEvent : IEvent;
    }
}