using TDS.Entities;
using TDS.Handlers;

namespace TDS.Events
{
    public class EntityRegisterEvents : ISubscriber
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

        public void Subscribe<TType>(IHandler<TType> handler)
        {
            _eventBus.Subscribe(handler);
        }

        public void Unsubscribe<TType>(IHandler<TType> handler)
        {
            _eventBus.Unsubscribe(handler);
        }
    }
}