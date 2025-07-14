using UnityEngine;

namespace TDS.Worlds
{
    public class RectangleTileMap : Map
    {
        public RectangleTileMap(Vector2Int size, IFactory<ITerrain,Bounds> terrainFactory)
        {
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Terrains.Add(terrainFactory.Create(new Bounds(new Vector3(x,y), Vector3.one)));
                }
            }
        }

        public RectangleTileMap(Vector2Int size) : this(size, new BoundsTerrainFactory())
        {
            
        }
    }
}