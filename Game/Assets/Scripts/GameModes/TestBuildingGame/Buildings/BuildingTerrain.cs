using TDS.Entities;
using TDS.Worlds;
using UnityEngine;
using Terrain = TDS.Worlds.Terrain;

namespace BuildingsTestGame
{
    public class BuildingTerrain : Terrain
    {
        private IBuilding _building;
        
        public IUnit Unit { get; set; }
        public IBuilding Building
        {
            get
            {
                return _building;
            }
            set
            {
                _building = value;
                _building.Terrain = this;
            }
        }
        
        public BuildingTerrain(IArea area) : base(area)
        {
            
        } 
    }
}