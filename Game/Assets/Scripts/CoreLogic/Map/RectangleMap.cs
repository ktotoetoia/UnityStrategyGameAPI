using System.Linq;
using TDS.Graphs;
using UnityEngine;

namespace TDS.Maps
{
    public class RectangleMap : Map, IGraphMap
    {
        private readonly GridGraph<ITerrain> _graph;
        public IGraphReadOnly<ITerrain> Graph => _graph;
        public ITerrain[,] TerrainsMatrix { get; }

        public Bounds MapBounds { get; }
        public Vector2Int TileCount { get; }
        public Vector2 TileSize { get; }
        
        public RectangleMap(Vector2Int tileCount) :this(tileCount,new BoundsTerrainFactory())
        {
            
        }
        
        public RectangleMap(Vector2Int tileCount, IFactory<ITerrain, Bounds> terrainFactory) : this(tileCount,new Bounds(Vector3.zero, new Vector3(tileCount.x,tileCount.y)),terrainFactory)
        {
            
        }

        public RectangleMap(Vector2Int tileCount, Bounds mapBounds) 
            : this(tileCount, mapBounds, new BoundsTerrainFactory())
        {
        }
        
        public RectangleMap(Vector2Int tileCount, Bounds mapBounds, IFactory<ITerrain, Bounds> terrainFactory)
        {
            TileCount = tileCount;
            MapBounds = mapBounds;

            TileSize = new Vector2(
                mapBounds.size.x / tileCount.x,
                mapBounds.size.y / tileCount.y
            );

            TerrainsMatrix = new ITerrain[tileCount.x, tileCount.y];
            _graph = new GridGraph<ITerrain>(tileCount.x, tileCount.y);

            Vector3 bottomLeft = mapBounds.center - mapBounds.extents;

            for (int x = 0; x < tileCount.x; x++)
            {
                for (int y = 0; y < tileCount.y; y++)
                {
                    Vector3 tileCenter = bottomLeft 
                                         + new Vector3((x + 0.5f) * TileSize.x, (y + 0.5f) * TileSize.y, 0f);

                    var tileBounds = new Bounds(tileCenter, new Vector3(TileSize.x, TileSize.y, 0f));
                    ITerrain terrain = terrainFactory.Create(tileBounds);

                    TerrainsCollection.Add(terrain);
                    TerrainsMatrix[x, y] = terrain;
                    _graph.NodeMatrix[x, y].Value = terrain;
                }
            }
        }

        public INode<ITerrain> GetNode(ITerrain terrain)
        {
            return _graph.Nodes.FirstOrDefault(x => x.Value == terrain);
        }
    }
}
