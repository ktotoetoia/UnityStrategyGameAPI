using TDS.Entities;

namespace BuildingsTestGame
{
    public class FirstBuilding : Building, IProductionBuilding
    {
        public void AddToQueue(IEntity unit)
        {
            Terrain.Unit =  unit;
        }
    }
}