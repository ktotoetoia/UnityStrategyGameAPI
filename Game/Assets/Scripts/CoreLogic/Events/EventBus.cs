using System;
using System.Collections.Generic;
using TDS.Handlers;

namespace TDS.Events
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<object>> _handlers = new();

        public void Subscribe<TEvent>(IHandler<TEvent> handler) where TEvent : IEvent
        {
            var type = typeof(TEvent);
            if (!_handlers.TryGetValue(type, out var list))
            {
                list = new List<object>();
                _handlers[type] = list;
            }
            list.Add(handler);
        }

        public void Unsubscribe<TEvent>(IHandler<TEvent> handler) where TEvent : IEvent
        {
            if (_handlers.TryGetValue(typeof(TEvent), out var list))
            {
                list.Remove(handler);
            }
        }

        public void Publish<TEvent>(TEvent evt) where TEvent : IEvent
        {
            foreach (var type in GetEventTypes(typeof(TEvent)))
            {
                if (_handlers.TryGetValue(type, out var list))
                {
                    foreach (var handler in list.ToArray())
                    {
                        if (handler is IHandler<TEvent> typedHandler)
                        {
                            typedHandler.Handle(evt);
                        }
                    }
                }
            }
        }

        private static IEnumerable<Type> GetEventTypes(Type type)
        {
            var seen = new HashSet<Type>();
            var queue = new Queue<Type>();
            queue.Enqueue(type);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current == null || !typeof(IEvent).IsAssignableFrom(current) || !seen.Add(current))
                    continue;

                yield return current;

                if (current.BaseType != null)
                    queue.Enqueue(current.BaseType);

                foreach (var iface in current.GetInterfaces())
                    queue.Enqueue(iface);
            }
        }
    }
}