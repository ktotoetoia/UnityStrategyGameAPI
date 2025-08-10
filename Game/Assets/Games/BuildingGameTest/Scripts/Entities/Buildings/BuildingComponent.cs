using TDS;
using TDS.Components;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class BuildingComponent : Component, IBuildingComponent
    {
        public void AddToQueue(IFactory<IBuilder<IEntity>> entityFactory)
        {
            IBuilder<IEntity> builder = entityFactory.Create();
            
            builder.Value.GetComponent<IHaveTerrain>().Terrain = Entity.GetComponent<IHaveTerrain>().Terrain;
            
            builder.FinishInitialization();
        }
    }
}