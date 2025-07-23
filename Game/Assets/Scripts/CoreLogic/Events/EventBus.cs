using System;
using System.Collections.Generic;
using System.Linq;

namespace TDS.Commands
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<object>> _handlers = new();

        public void Subscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            Type eventType = typeof(TEvent);
            
            if (!_handlers.ContainsKey(eventType))
            {
                _handlers[eventType] = new List<object>();
            }

            _handlers[eventType].Add(handler);
        }

        public void Unsubscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            Type eventType = typeof(TEvent);
            
            if (_handlers.TryGetValue(eventType, out var list))
            {
                list.Remove(handler);
            }
        }

        public void Publish<TEvent>(TEvent evt) where TEvent : IEvent
        {
            Type eventType = typeof(TEvent);
            
            if (_handlers.TryGetValue(eventType, out var list))
            {
                foreach (IEventHandler<TEvent> handler in list.Cast<IEventHandler<TEvent>>())
                {
                    handler.Handle(evt);
                }
            }
        }
    }
}