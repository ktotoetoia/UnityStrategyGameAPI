using System.Linq;
using TDS.Systems;
using TDS.Worlds;
using UnityEngine;

namespace BuildingsTestGame
{
    public class TerrainSelector : ISystem
    {
        private readonly IMap _map;
        
        public ITerrain Selected { get; private set; }
        public bool IsSelected => Selected != null;
        
        public TerrainSelector(IMap map)
        {
            _map = map;
        }

        public void SelectAt(Vector2 position)
        {
            Selected = _map.GetTerrainsAt(position).FirstOrDefault();
        }
    }
}