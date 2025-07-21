using System.Collections.Generic;
using TDS.Worlds;
using UnityEngine;
using Terrain = TDS.Worlds.Terrain;

namespace TDS
{
    public class MonoWorldFactory : MonoBehaviour, IFactory<World>
    {
        [SerializeField] private List<Bounds> _terrain;
        [SerializeField] private List<string> _names;
        [SerializeField] private List<Color> _colors;

        public World Create()
        {
            Map map = new Map();
            
            _terrain.ForEach(x => map.TerrainsCollection.Add(new Terrain("empty", new BoundsArea(x))));
            
            return new World(map);
        }
    }
}