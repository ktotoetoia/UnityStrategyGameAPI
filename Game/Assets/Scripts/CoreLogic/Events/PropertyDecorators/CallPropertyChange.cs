using System;
using System.Collections.Generic;
using TDS.Handlers;
using UnityEngine;

namespace TDS.Events
{
    public class CallPropertyChange<T> : ICallPropertyChange<T>
    {
        private List<IHandler<IPropertyChangeEvent>> _handlers = new();
        private object Owner;
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                T oldValue = _value;
                _value = value;
                
                foreach (var handler in _handlers)
                {
                    handler.Handle(new PropertyChangeEvent<T, object>(oldValue, _value, Owner));
                }
            }
        }

        public CallPropertyChange(object owner, T value)
        {
            Owner = owner;
            Value = value;
        }

        public CallPropertyChange(object owner)
        {
            Owner = owner;
        }

        public void Subscribe<TOwner>(IHandler<PropertyChangeEvent<T, TOwner>> handler)
        {
            _handlers.Add(new HandlerWrapper<T, TOwner>(handler));
        }

        public void Unsubscribe<TOwner>(IHandler<PropertyChangeEvent<T, TOwner>> handler)
        {
            _handlers.RemoveAll(h => h is HandlerWrapper<T, TOwner> wrapper && wrapper.Inner == handler);
        }
    }
}