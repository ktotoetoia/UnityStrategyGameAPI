using TDS.Entities;

namespace BuildingsTestGame
{
    public class EntityAddedEvent :SingleValueEvent<IEntity>
    {
        public EntityAddedEvent(IEntity entity) : base(entity)
        {
            
        }
    }
}