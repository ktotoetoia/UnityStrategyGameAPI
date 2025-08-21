using TDS.Entities;

namespace TDS.Events
{
    public class EntityRemovedEvent : SingleValueEvent<IEntity>
    {
        public EntityRemovedEvent(IEntity entity) : base(entity)
        {
            
        }
    }
}