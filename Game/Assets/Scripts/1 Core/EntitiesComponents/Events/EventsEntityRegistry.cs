using System.Collections;
using System.Collections.Generic;
using TDS.Entities;
using TDS.Handlers;

namespace TDS.Events
{
    public class EventsEntityRegistry : IEventsEntityRegistry
    {
        private readonly IEventBus _eventBus;
        private readonly IEntityRegistry _entityRegistry;

        public EventsEntityRegistry() : this(new EntityRegistry())
        {
            
        }

        public EventsEntityRegistry(EntityRegistry entityRegistry)
        {
            _entityRegistry = entityRegistry;
            _eventBus =  new EventBus();
            
            entityRegistry.OnEntityAdded += x =>
            {
                _eventBus.Publish(new EntityAddedEvent(x));
            };
            entityRegistry.OnEntityRemoved += x =>
            {
                _eventBus.Publish(new EntityRemovedEvent(x));
            };
        }

        public void Subscribe<TType>(IHandler<TType> handler)
        {
            _eventBus.Subscribe(handler);
        }

        public void Unsubscribe<TType>(IHandler<TType> handler)
        {
            _eventBus.Unsubscribe(handler);
        }

        public IEnumerator<IEntity> GetEnumerator()
        {
            return _entityRegistry.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_entityRegistry).GetEnumerator();
        }

        public IEnumerable<IEntity> Entities => _entityRegistry.Entities;

        public void AddEntity(IEntity entity)
        {
            _entityRegistry.AddEntity(entity);
        }

        public void RemoveEntity(IEntity entity)
        {
            _entityRegistry.RemoveEntity(entity);
        }

        public bool Contains(IEntity entity)
        {
            return _entityRegistry.Contains(entity);
        }
    }
}