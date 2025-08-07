using TDS.Entities;

namespace BuildingsTestGame
{
    public class EventEntityInitializer : IEntityInitializer
    {
        public void Initialize(IEntity entity)
        {
            if (entity.TryGetComponent(out IEventComponent eventComponent) && entity.TryGetComponent(out ITerrainComponent terrainComponent))
            {
                eventComponent.Publish(new EntityInitializedEvent(entity,terrainComponent.Terrain));
            }
        }
    }
}