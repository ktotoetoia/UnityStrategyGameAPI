using TDS;
using TDS.Commands;

namespace BuildingsTestGame
{
    public class AddUnitCreationToBuildingQueue : Command
    {
        public IProductionBuilding Building { get; }
        public IFactory<IUnit>  EntityFactory { get; }

        public AddUnitCreationToBuildingQueue(IProductionBuilding building, IFactory<IUnit> entityFactory)
        {
            Building = building;
            EntityFactory = entityFactory;
        }
    }
}