using System.Collections.Generic;
using TDS;
using TDS.Entities;
using TDS.Worlds;
using UnityEngine;

namespace BuildingsTestGame
{
    public class BuildingGameFactory : IFactory<BuildingGame>
    {
        public Vector2Int Size { get; set; }
        public Vector2Int StartingPosition { get; set; }
        
        public BuildingGameFactory(Vector2Int size)
        {
            Size = size;
        }
        
        public BuildingGame Create()
        {
            return new BuildingGame(CreateWorld());
        }

        private World CreateWorld()
        {
            RectangleTileMap  tileMap = new RectangleTileMap(Size,new BuildingTerrainFactory());
            
            SetBase(tileMap);
            
            return new World(tileMap);
        }

        private void SetBase(RectangleTileMap tileMap)
        {
            (tileMap.TerrainsMatrix[StartingPosition.x, StartingPosition.y] as BuildingTerrain).Building = new FirstBuilding();
        }
    }
}