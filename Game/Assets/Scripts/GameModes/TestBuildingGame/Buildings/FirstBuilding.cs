using System.Linq;
using TDS;
using TDS.Entities;

namespace BuildingsTestGame
{
    public class FirstBuilding : Building, IProductionBuilding
    {
        public void AddToQueue(IFactory<IUnit> entityFactory)
        {
            Terrain.Unit = entityFactory.Create();
        }
    }
}