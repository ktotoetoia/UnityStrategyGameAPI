using System;
using System.Collections.Generic;

namespace TDS.Events
{
    public class CallPropertyChange<T, TOwner> : ICallPropertyChange<T, TOwner>
    {
        private T _value;
        
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                T oldValue = _value;
                _value = value;
                
                if (!EqualityComparer<T>.Default.Equals(oldValue, _value))
                {
                    EventPublisher.Publish(new PropertyChangeEvent<T,TOwner>(oldValue, _value,Owner));
                }
            }
        }
        
        public IEventPublisher  EventPublisher { get; }
        public TOwner Owner { get; }

        public CallPropertyChange(TOwner owner, IEventPublisher eventPublisher) : this(default, owner, eventPublisher)
        {
            
        }

        public CallPropertyChange(T value, TOwner owner, IEventPublisher  eventPublisher)
        {
            _value = value;
            Owner = owner;
            EventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
        }
    }
}