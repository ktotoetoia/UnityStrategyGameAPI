using TDS;

namespace BuildingsTestGame
{
    public class FirstBuilding : Building, IProductionBuilding
    {
        public void AddToQueue(IFactory<IUnit> entityFactory)
        {
            Terrain.Unit = entityFactory.Create();
            Terrain.Unit.Events.Publish(new UnitCreatedEvent(Terrain.Unit,Terrain));
        }
    }
}