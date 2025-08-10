using TDS;
using TDS.Commands;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class AddUnitCreationToBuildingQueue : Command
    {
        public IBuildingComponent Building { get; }
        public IFactory<IBuilder<IEntity>>  EntityFactory { get; }

        public AddUnitCreationToBuildingQueue(IBuildingComponent building, IFactory<IBuilder<IEntity>> entityFactory)
        {
            Building = building;
            EntityFactory = entityFactory;
        }
    }
}