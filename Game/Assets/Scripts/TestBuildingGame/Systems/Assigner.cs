using TDS.Entities;
using TDS.Systems;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public class Assigner : ISystem
    {
        public void Assign(ITerrain terrain, IUnit unit)
        {
            if (CanAssignUnit(terrain))
            {
                (terrain as BuildingTerrain).Unit = unit;
            }
        }
        
        public bool CanAssignUnit(ITerrain terrain)
        {
            return terrain is BuildingTerrain t && t.Unit == null;
        }

        public void Assign(ITerrain terrain, IBuilding building)
        {
            if (CanAssignBuilding(terrain))
            {
                (terrain as BuildingTerrain).Building = building;
            }
        }

        public bool CanAssignBuilding(ITerrain terrain)
        {
            return terrain is BuildingTerrain t && t.Building == null;
        }
    }
}