using System.Collections.Generic;
using System.Linq;
using BuildingsTestGame;
using TDS.Events;
using TDS.Handlers;
using TDS.Maps;
using UnityEngine;

namespace TDS.Entities
{
    public class TerrainDistributor : MonoBehaviour
    {
        private readonly List<IHandler<ITerrain>> TerrainDrawers = new();
        private BuildingGame _game;

        public BuildingGame Game
        {
            get => _game;
            set
            {
                _game = value;

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
            GetComponents(TerrainDrawers);
        }
    }
}