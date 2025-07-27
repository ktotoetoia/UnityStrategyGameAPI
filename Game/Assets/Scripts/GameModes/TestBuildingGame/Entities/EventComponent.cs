using TDS.Commands;
using TDS.Components;
using TDS.Events;

namespace BuildingsTestGame
{
    public class EventComponent : Component, IEventComponent
    {
        private IEventBus<IEvent> _events = new EventBus(); 
        
        public void Subscribe(IEventHandler handler)
        {
            _events?.Subscribe(handler);
        }

        public void Unsubscribe(IEventHandler handler)
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