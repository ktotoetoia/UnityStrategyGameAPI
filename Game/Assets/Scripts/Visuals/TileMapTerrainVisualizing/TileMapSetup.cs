using System.Collections.Generic;
using TDS.Events;
using TDS.Handlers;
using TDS.Maps;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TDS.Entities
{
    public class TileMapSetup : MonoBehaviour
    {
        private readonly List<IHandler<ITerrain>> TerrainDrawers = new();
        private IMap _map;
        private Tilemap _tilemap;

        public IMap Map
        {
            get => _map;
            set
            {
                _map = value;
                
                if (_map is RectangleMap map)
                {
                    new RectangleMapGridSetup().Setup(map,_tilemap.layoutGrid);
                }

                foreach (ITerrain terrain in _map.Terrains)
                {
                    foreach (IHandler<ITerrain> terrainDrawer in TerrainDrawers)
                    {
                        if (terrainDrawer.TryHandle(terrain))
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void Awake()
        {
            _tilemap = GetComponent<Tilemap>();
            GetComponents(TerrainDrawers);
        }
    }
}