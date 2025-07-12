using TDS.Entities;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public class BuildingTerrain : Terrain
    {
        public IUnit Unit { get; set; }
        public IBuilding Building { get; set; }
        
        public BuildingTerrain(IArea area) : base(area)
        {
            
        } 
    }
}