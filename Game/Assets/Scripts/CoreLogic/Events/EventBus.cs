using System;
using System.Collections.Generic;
using System.Linq;
using TDS.Handlers;

namespace TDS.Events
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<object>> _handlers = new();

        public void Subscribe<TEvent>(IHandler<TEvent> handler) where TEvent : IEvent
        {
            Type type = typeof(TEvent);
            
            if (!_handlers.TryGetValue(type, out var list))
            {
                list = new List<object>();
                _handlers[type] = list;
            }
            
            list.Add(handler);
        }

        public void Unsubscribe<TEvent>(IHandler<TEvent> handler) where TEvent : IEvent
        {
            Type type = typeof(TEvent);
            
            if (_handlers.TryGetValue(type, out var list))
            {
                list.Remove(handler);
            }
        }

        public void Publish<TEvent>(TEvent evt) where TEvent : IEvent
        {
            foreach (var type in GetTypeHierarchy(typeof(TEvent)))
            {
                if (_handlers.TryGetValue(type, out var list))
                {
                    foreach (var handlerObj in list)
                    {
                        if (handlerObj is IHandler<TEvent> exactHandler)
                        {
                            exactHandler.Handle(evt);
                        }
                        else if (handlerObj is IHandler<IEvent> genericHandler)
                        {
                            genericHandler.Handle(evt);
                        }
                    }
                }
            }
        }

        private IEnumerable<Type> GetTypeHierarchy(Type type)
        {
            var seen = new HashSet<Type>();

            while (type != null && typeof(IEvent).IsAssignableFrom(type))
            {
                if (seen.Add(type))
                    yield return type;

                foreach (var iface in type.GetInterfaces())
                {
                    if (typeof(IEvent).IsAssignableFrom(iface) && seen.Add(iface))
                        yield return iface;
                }

                type = type.BaseType;
            }
        }
    }
}