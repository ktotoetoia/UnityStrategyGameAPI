using TDS.Handlers;

namespace TDS.Events
{
    public interface IEventBus : IEventBus<IEvent>
    {
        
    }
    
    public interface IEventBus<in T>: IEventPublisher<T>, IEventSubscriber
        where T : IEvent
    {
        
    }

    public interface IEventPublisher<in TEvent> where TEvent : IEvent
    {
        void Publish(TEvent evt);
    }

    public interface IEventSubscriber
    {
        void Subscribe(IHandler<IEvent> handler);
        void Unsubscribe(IHandler<IEvent> handler);
    }
}