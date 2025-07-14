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
            return new World(new RectangleTileMap(Size,new BuildingTerrainFactory()));
        }
    }
}