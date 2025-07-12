using System.Collections.Generic;
using TDS.Factions;
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
            IMap map = new Map();
            
            _terrain.ForEach(x => map.Terrains.Add(new Terrain("empty", new BoundsArea(x))));
            
            return new World(map);
        }
    }
}