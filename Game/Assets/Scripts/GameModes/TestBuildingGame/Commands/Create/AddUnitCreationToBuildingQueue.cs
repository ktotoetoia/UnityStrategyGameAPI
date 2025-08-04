using TDS;
using TDS.Commands;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class AddUnitCreationToBuildingQueue : Command
    {
        public IProductionBuilding Building { get; }
        public IFactory<IEntity>  EntityFactory { get; }

        public AddUnitCreationToBuildingQueue(IProductionBuilding building, IFactory<IEntity> entityFactory)
        {
            Building = building;
            EntityFactory = entityFactory;
        }
    }
}