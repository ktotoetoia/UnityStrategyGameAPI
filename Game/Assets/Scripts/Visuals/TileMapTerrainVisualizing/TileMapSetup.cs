using TDS.Handlers;
using TDS.Maps;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TDS.Entities
{
    public class TileMapSetup : MonoBehaviour
    {
        private IHandler<ITerrain> _terrainDrawer;
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
                    _terrainDrawer.Handle(terrain);
                }
            }
        }

        private void Awake()
        {
            _tilemap = GetComponent<Tilemap>();
            _terrainDrawer = GetComponent<IHandler<ITerrain>>();
        }
    }
}