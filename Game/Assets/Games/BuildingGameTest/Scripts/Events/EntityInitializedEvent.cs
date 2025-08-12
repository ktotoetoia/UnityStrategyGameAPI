using TDS.Entities;
using TDS.Events;

namespace BuildingsTestGame
{
    public class EntityInitializedEvent : IEvent
    {
        public IEntity Entity { get; }
        public IGameTerrainComponent Terrain { get; }

        public EntityInitializedEvent(IEntity entity, IGameTerrainComponent terrain)
        {
            Entity = entity;
            Terrain = terrain;
        }
    }
}