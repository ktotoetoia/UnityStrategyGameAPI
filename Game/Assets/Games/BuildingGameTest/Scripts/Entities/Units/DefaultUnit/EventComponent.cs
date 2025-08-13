using TDS.Components;
using TDS.Events;
using TDS.Handlers;

namespace BuildingsTestGame
{
    public class EventComponent : Component, IEventComponent
    {
        private IEventBus _events = new EventBus(); 

        public void Publish<TType>(TType evt)
        {
            ThrowExceptionIfDestroyed();
            _events?.Publish(evt);
        }

        public void Subscribe<TType>(IHandler<TType> handler)
        {
            ThrowExceptionIfDestroyed();
            _events?.Subscribe(handler);
        }

        public void Unsubscribe<TType>(IHandler<TType> handler)
        {
            ThrowExceptionIfDestroyed();
            _events?.Unsubscribe(handler);
        }
        
        public override void Destroy()
        {
            base.Destroy();
            _events =  null;
        }
    }
}