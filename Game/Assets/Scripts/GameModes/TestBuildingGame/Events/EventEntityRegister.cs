using System.Collections;
using System.Collections.Generic;
using TDS.Commands;
using TDS.Entities;
using TDS.Events;
using TDS.Handlers;

namespace BuildingsTestGame
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
        
        public void Subscribe(IHandler<IEvent> handler)
        {
            _eventBus.Subscribe(handler);
        }

        public void Unsubscribe(IHandler<IEvent> handler)
        {
            _eventBus.Unsubscribe(handler);
        }
    }
}