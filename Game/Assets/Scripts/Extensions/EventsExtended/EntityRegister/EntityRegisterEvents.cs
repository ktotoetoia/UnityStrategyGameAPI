using TDS.Entities;
using TDS.Handlers;
using UnityEngine;

namespace TDS.Events
{
    public class EntityRegisterEvents : IEventSubscriber
    {
        private readonly IEventBus _eventBus;

        public EntityRegisterEvents(EntityRegister entityRegister)
        {
            _eventBus =  new EventBus();
            
            entityRegister.OnEntityAdded += x =>
            {
                _eventBus.Publish(new EntityAddedEvent(x));
            };
            entityRegister.OnEntityRemoved += x =>
            {
                _eventBus.Publish(new EntityRemovedEvent(x));
            };
        }

        public void Subscribe<TEvent>(IHandler<TEvent> handler) where TEvent : IEvent
        {
            _eventBus.Subscribe(handler);
        }

        public void Unsubscribe<TEvent>(IHandler<TEvent> handler) where TEvent : IEvent
        {
            _eventBus.Unsubscribe(handler);
        }
    }
}