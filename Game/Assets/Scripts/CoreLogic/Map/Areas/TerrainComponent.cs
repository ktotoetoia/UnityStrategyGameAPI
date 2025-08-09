using TDS.Components;
using TDS.Entities;

namespace TDS.Maps
{
    public class TerrainComponent : Component, ITerrainComponent
    {
        public ITerrain Terrain { get; private set; }

        public override void Init(IEntity entity)
        {
            if (entity is not ITerrain terrain)
            {
                throw new System.Exception("Entity is not ITerrain");
            }

            Terrain = terrain;
            
            base.Init(entity);
        }
    }
}