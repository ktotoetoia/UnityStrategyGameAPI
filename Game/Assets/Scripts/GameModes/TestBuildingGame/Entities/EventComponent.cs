using TDS.Commands;
using TDS.Components;
using TDS.Events;
using TDS.Handlers;

namespace BuildingsTestGame
{
    public class EventComponent : Component, IEventComponent
    {
        private IEventBus<IEvent> _events = new EventBus(); 
        
        public void Subscribe(IHandler<IEvent> handler)
        {
            _events?.Subscribe(handler);
        }

        public void Unsubscribe(IHandler<IEvent> handler)
        {
            _events?.Unsubscribe(handler);
        }

        public void Publish(IEvent evt)
        {
            _events?.Publish(evt);
        }
        
        public override void Destroy()
        {
            _events =  null;
        }
    }
}