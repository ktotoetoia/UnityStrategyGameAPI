using System.Collections.Generic;
using TDS;
using TDS.Systems;

namespace BuildingsTestGame
{
    public class BuildingCreation : ISystem
    {
        private List<BuildingType> _buildingTypes;

        public BuildingCreation() : this(new List<BuildingType>() {new ("Default", new DynamicFactory<IBuilding>(() => new Building()))})
        {
            
        }
        
        public BuildingCreation(List<BuildingType> buildingTypes)
        {
            _buildingTypes = buildingTypes;
        }

        public IBuilding Create()
        {
            return Create(_buildingTypes[0]);
        }

        public IBuilding Create(BuildingType buildingType)
        {
            IBuilding building = buildingType.Factory.Create();
            return building;
        }

        public void RemoveBuilding(BuildingTerrain terrain)
        {
            terrain.Building = null;
        }

        public IEnumerable<BuildingType> AvailableBuildingTypes()
        {
            return _buildingTypes;
        }
    }
}