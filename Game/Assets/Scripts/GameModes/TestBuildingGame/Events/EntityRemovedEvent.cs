using TDS.Entities;
using TDS.Events;

namespace BuildingsTestGame
{
    public class EntityRemovedEvent : SingleValueEvent<IEntity>
    {
        public EntityRemovedEvent(IEntity entity) : base(entity)
        {
            
        }
    }
}