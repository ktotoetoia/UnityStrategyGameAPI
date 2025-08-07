using TDS.Entities;
using TDS.Events;

namespace BuildingsTestGame
{
    public class EntityInitializedEvent : IEvent
    {
        public IEntity Entity { get; }
        public IGameTerrain Terrain { get; }

        public EntityInitializedEvent(IEntity entity, IGameTerrain terrain)
        {
            Entity = entity;
            Terrain = terrain;
        }
    }
}