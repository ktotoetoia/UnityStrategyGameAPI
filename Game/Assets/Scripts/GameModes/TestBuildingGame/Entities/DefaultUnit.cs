using TDS.Entities;

namespace BuildingsTestGame
{
    public class DefaultUnit : Entity
    {
        public IEventComponent EventComponent { get; }
        
        public DefaultUnit()
        {
            EventComponent = new EventComponent();
            AddComponent(EventComponent);
        }
    }
}