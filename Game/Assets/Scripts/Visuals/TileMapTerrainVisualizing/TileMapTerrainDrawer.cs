using TDS.Handlers;
using TDS.Maps;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TDS.Entities
{
    public class TileMapTerrainDrawer : MonoBehaviour, IConditionalHandler<ITerrain>
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Tile _tile;
        [SerializeField] private Grid _grid;
        public bool CanHandle(ITerrain operation)
        {
            return true;
        }

        public void Handle(ITerrain terrain)
        {
            _tilemap.SetTile(_tilemap.WorldToCell(terrain.Transform.Position), _tile);
        }
    }
}