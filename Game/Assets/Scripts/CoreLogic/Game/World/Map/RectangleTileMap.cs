using TDS.Graphs;
using UnityEngine;

namespace TDS.Worlds
{
    public class RectangleTileMap : Map
    {
        public ITerrain[,] TerrainsMatrix { get; }
        public IGraph Graph { get; }
         
        public RectangleTileMap(Vector2Int size, IFactory<ITerrain,Bounds> terrainFactory)
        {
            TerrainsMatrix = new ITerrain[size.x, size.y];
            
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    ITerrain terrain = terrainFactory.Create(new Bounds(new Vector3(x, y), Vector3.one));
                    
                    TerrainsCollection.Add(terrain);
                    TerrainsMatrix[x,y]  = terrain;
                }
            }
        }

        public RectangleTileMap(Vector2Int size) : this(size, new BoundsTerrainFactory())
        {
            
        }
    }
}