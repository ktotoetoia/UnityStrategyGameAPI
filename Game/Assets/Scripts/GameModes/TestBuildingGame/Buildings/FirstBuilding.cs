using TDS.Entities;

namespace BuildingsTestGame
{
    public class FirstBuilding : Building, IProductionBuilding
    {
        public void AddToQueue(IUnit unit)
        {
            unit.Transform.SetPosition(Terrain.Area.Position);
            Terrain.Unit =  unit;
        }
    }
}