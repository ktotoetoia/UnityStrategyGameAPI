using System;
using TDS.Handlers;

namespace TDS.Events
{
    public class SingleTimeEventHandler<T> : IHandler<T> where T : IEvent
    {
        private readonly Action<T> _handler;
        private readonly Func<T, bool> _canHandle;
        private ISubscriber _events;
        
        public SingleTimeEventHandler(Action<T> handler,ISubscriber events) : this(handler, x => true,events)
        {
            
        }

        public SingleTimeEventHandler(Action<T> handler, Func<T, bool> canHandle, ISubscriber events)
        {
            _events = events;
            _handler = handler;
            _canHandle = canHandle;
        }

        public bool CanHandle(T operation)
        {
            return _canHandle(operation);
        }

        public void Handle(T operation)
        {
            if (_canHandle(operation))
            {
                _handler(operation);
                _events.Unsubscribe(this);
            }
        }
    }
}