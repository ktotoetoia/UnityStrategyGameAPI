using TDS.Graphs;
using UnityEngine;

namespace TDS.Worlds
{
    public class RectangleTileMap : Map
    {
        private GridGraph _graph;
        public GridGraph Graph => _graph;
        public ITerrain[,] TerrainsMatrix { get; }
        
        public RectangleTileMap(Vector2Int gridSize) : this(gridSize, new BoundsTerrainFactory())
        {
            
        }
        
        public RectangleTileMap(Vector2Int gridSize, IFactory<ITerrain, Bounds> terrainFactory) : this(gridSize,terrainFactory,Vector2.one)
        {
            
        }
        
        public RectangleTileMap(Vector2Int gridSize, IFactory<ITerrain,Bounds> terrainFactory,Vector2 tileSize)
        {
            TerrainsMatrix = new ITerrain[gridSize.x, gridSize.y];
            Vector2 offset = gridSize * tileSize / 2 - tileSize / 2;
            _graph = new GridGraph(gridSize.x, gridSize.y);
            
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    ITerrain terrain = terrainFactory.Create(new Bounds(new Vector3(x, y) * tileSize - offset, tileSize));
                    
                    TerrainsCollection.Add(terrain);
                    TerrainsMatrix[x, y] = terrain;
                    _graph.NodeMatrix[x,y].Value = TerrainsMatrix[x, y];
                }
            }
        }
    }
}