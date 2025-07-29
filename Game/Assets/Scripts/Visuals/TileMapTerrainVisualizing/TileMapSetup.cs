using System.Collections.Generic;
using BuildingsTestGame;
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
        private BuildingGame _game;
        private Tilemap _tilemap;

        public BuildingGame Game
        {
            get => _game;
            set
            {
                _game = value;
                
                if (_game.Map is RectangleMap map)
                {
                    new RectangleMapGridSetup().Setup(map,_tilemap.layoutGrid);
                }

                foreach (ITerrain terrain in _game.Map.Terrains)
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