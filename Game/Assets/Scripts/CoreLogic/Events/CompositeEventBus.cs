namespace TDS.Events
{
    public class CompositeEventBus : IEventBus, IEventHandler
    {
        private readonly IEventBus _eventBus;

        public CompositeEventBus() : this(new EventBus()) {}

        public CompositeEventBus(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void Subscribe(IEventHandler handler)
        {
            _eventBus.Subscribe(handler);
        }

        public void Unsubscribe(IEventHandler handler)
        {
            _eventBus.Unsubscribe(handler);
        }

        public void Publish(IEvent evt)
        {
            _eventBus.Publish(evt);
        }

        public bool CanHandle(IEvent evt) => true;

        public void Handle(IEvent evt)
        {
            Publish(evt);
        }
    }
}