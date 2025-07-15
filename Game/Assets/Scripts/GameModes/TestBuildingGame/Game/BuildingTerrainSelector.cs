using TDS.SelectionSystem;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public class BuildingTerrainSelector : TerrainSelector
    {
        public BuildingTerrainSelector(IMap map):base(map)
        {
            Allow = terrain => terrain is BuildingTerrain ter && (ter.Unit !=null || ter.Building != null);
        }
    }
}