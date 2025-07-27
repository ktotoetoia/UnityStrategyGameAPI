using System.Linq;
using TDS.Graphs;
using UnityEngine;

namespace TDS.Maps
{
    public class RectangleTileMap : Map, IGraphMap
    {
        private GridGraph<ITerrain> _graph;
        public IGraphReadOnly<ITerrain> Graph => _graph;
        public ITerrain[,] TerrainsMatrix { get; }
        
        public RectangleTileMap(Vector2Int gridSize) : this(gridSize, new BoundsTerrainFactory())
        {
            
        }
        
        public RectangleTileMap(Vector2Int tileCount, IFactory<ITerrain, Bounds> terrainFactory) : this(tileCount,Vector2.one, terrainFactory)
        {
            
        }
        
        public RectangleTileMap(Vector2Int tileCount, Vector2 tileSize, IFactory<ITerrain, Bounds> terrainFactory)
        {
            TerrainsMatrix = new ITerrain[tileCount.x, tileCount.y];
            Vector2 offset = tileCount * tileSize / 2 - tileSize / 2;
            _graph = new GridGraph<ITerrain>(tileCount.x, tileCount.y);
            
            for (int x = 0; x < tileCount.x; x++)
            {
                for (int y = 0; y < tileCount.y; y++)
                {
                    ITerrain terrain = terrainFactory.Create(new Bounds(new Vector3(x, y) * tileSize - offset, tileSize));
                    
                    TerrainsCollection.Add(terrain);
                    TerrainsMatrix[x, y] = terrain;
                    _graph.NodeMatrix[x,y].Value = TerrainsMatrix[x, y];
                }
            }
        }

        public INode<ITerrain> GetNode(ITerrain terrain)
        {
            return _graph.Nodes.FirstOrDefault(x => x.Value == terrain);
        }
    }
}