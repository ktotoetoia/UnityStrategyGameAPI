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
                    EventBus.Publish(new PropertyChangeEvent<T,TOwner>(oldValue, _value,Owner));
                }
            }
        }
        
        public IEventBus EventBus { get; }
        public TOwner Owner { get; }

        public CallPropertyChange(TOwner owner, IEventBus eventBus) : this(default, owner, eventBus)
        {
            
        }

        public CallPropertyChange(T value, TOwner owner, IEventBus eventBus)
        {
            _value = value;
            Owner = owner;
            EventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }
    }
}