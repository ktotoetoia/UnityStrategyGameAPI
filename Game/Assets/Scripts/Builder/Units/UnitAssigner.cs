using TDS.Entities;
using TDS.Systems;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public class UnitAssigner : ISystem
    {
        public void Assign(ITerrain terrain, IUnit unit)
        {
            if (CanAssign(terrain))
            {
                (terrain as BuildingTerrain).Unit = unit;
            }
        }
        
        public bool CanAssign(ITerrain terrain)
        {
            return terrain is BuildingTerrain t && t.Unit == null;
        }
    }
}