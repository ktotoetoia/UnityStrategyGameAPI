using TDS;
using TDS.Components;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class BuildingComponent : Component, IBuildingComponent
    {
        public void AddToQueue(IFactory<IEntity> entityFactory)
        {
            IEntity entity = entityFactory.Create();
            
            Entity.GetComponent<IMovementOnTerrain>().Terrain.Unit = entity;
            
            new EventEntityInitializer().Initialize(entity);
        }
    }
}