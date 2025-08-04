using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class FirstBuilding : Building, IProductionBuilding
    {
        public void AddToQueue(IFactory<IEntity> entityFactory)
        {
            Terrain.Unit = entityFactory.Create();

            if (Terrain.Unit.TryGetComponent(out IEventComponent eventComponent))
            {
                eventComponent.Publish(new UnitCreatedEvent(Terrain.Unit,Terrain));
            }
        }
    }
}