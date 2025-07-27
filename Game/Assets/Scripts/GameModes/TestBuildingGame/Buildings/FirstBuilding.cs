using TDS.Entities;

namespace BuildingsTestGame
{
    public class FirstBuilding : Building, IProductionBuilding
    {
        public void AddToQueue(IUnit unit)
        {
            Terrain.Unit =  unit;
        }
    }
}