using TDS.Components;
using TDS.Events;
using TDS.Handlers;

namespace BuildingsTestGame
{
    public class EventComponent : Component, IEventComponent
    {
        private IEventBus _events = new EventBus(); 

        public void Publish<TEvent>(TEvent evt) where TEvent : IEvent
        {
            _events?.Publish(evt);
        }

        public void Subscribe<TEvent>(IHandler<TEvent> handler) where TEvent : IEvent
        {
            _events?.Subscribe(handler);
        }

        public void Unsubscribe<TEvent>(IHandler<TEvent> handler) where TEvent : IEvent
        {
            _events?.Unsubscribe(handler);
        }
        
        public override void Destroy()
        {
            base.Destroy();
            _events =  null;
        }
    }
}