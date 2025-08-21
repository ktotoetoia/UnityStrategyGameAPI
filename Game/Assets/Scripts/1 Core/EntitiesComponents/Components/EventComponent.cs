using System.Collections.Generic;
using TDS.Components;
using TDS.Entities;
using TDS.Events;
using TDS.Handlers;

namespace BuildingsTestGame
{
    public class EventComponent : Component, IEventComponent
    {
        private IEventBus _events; 
        private IPropertyChangeRegistry _propertyEvents;
        
        public IEnumerable<object> Source => _propertyEvents.Source;

        public override void Init(IEntity entity)
        {
            base.Init(entity);

            _events = new EventBus();
            _propertyEvents = new PropertyChangeRegistry(Entity.Components);
        }

        public void Publish<TType>(TType evt)
        {
            ThrowExceptionIfDestroyed();
            _events?.Publish(evt);
        }

        public void Subscribe<TType>(IHandler<TType> handler)
        {
            ThrowExceptionIfDestroyed();
            _events?.Subscribe(handler);
        }

        public void Unsubscribe<TType>(IHandler<TType> handler)
        {
            ThrowExceptionIfDestroyed();
            _events?.Unsubscribe(handler);
        }
        
        public override void Destroy()
        {
            base.Destroy();
            _events =  null;
            _propertyEvents =  null;
        }

        public void Subscribe<TPropertyType, TOwnerType>(string propertyName, IHandler<PropertyChangeEvent<TPropertyType, TOwnerType>> handler)
        {
            _propertyEvents.Subscribe(propertyName, handler);
        }

        public void Unsubscribe<TPropertyType, TOwnerType>(string propertyName, IHandler<PropertyChangeEvent<TPropertyType, TOwnerType>> handler)
        {
            _propertyEvents.Unsubscribe(propertyName, handler);
        }
    }
}