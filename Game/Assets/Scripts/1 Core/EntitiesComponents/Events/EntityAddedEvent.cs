using TDS.Entities;

namespace TDS.Events
{
    public class EntityAddedEvent :SingleValueEvent<IEntity>
    {
        public EntityAddedEvent(IEntity entity) : base(entity)
        {
            
        }
    }
}