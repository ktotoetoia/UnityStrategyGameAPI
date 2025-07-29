using System.Collections.Generic;
using System.Linq;
using TDS.Handlers;

namespace TDS.Events
{
    public class EventBus : IEventBus
    {
        private readonly List<IHandler<IEvent>> _handlers = new();

        public void Subscribe(IHandler<IEvent> handler)
        {
            _handlers.Add(handler);
        }

        public void Unsubscribe(IHandler<IEvent> handler)
        {
            _handlers.Remove(handler);
        }

        public void Publish(IEvent evt)
        {
            foreach (var handler in _handlers)
            {
                if (handler.CanHandle(evt))
                {
                    handler.Handle(evt);
                }
            }
        }
    }
}