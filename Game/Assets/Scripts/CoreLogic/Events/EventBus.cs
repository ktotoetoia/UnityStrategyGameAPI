using System;
using System.Collections.Generic;
using System.Linq;

namespace TDS.Events
{
    public class EventBus : IEventBus
    {
        private readonly List<IEventHandler> _handlers = new();

        public void Subscribe(IEventHandler handler)
        {
            _handlers.Add(handler);
        }

        public void Unsubscribe(IEventHandler handler)
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