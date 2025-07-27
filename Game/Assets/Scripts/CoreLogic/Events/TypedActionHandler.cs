using System;

namespace TDS.Events
{
    public class TypedActionHandler<T> : IEventHandler
    {
        private Action<T> _handler;
        
        public TypedActionHandler(Action<T> handler)
        {
            _handler = handler; 
        }
        
        public bool CanHandle(IEvent evt)
        {
            return evt is T;
        }

        public void Handle(IEvent evt)
        {
            if (evt is T evt1)
            {
                _handler(evt1);
            }
        }
    }
}