using System.Collections.Generic;
using TDS.Maps;
using UnityEngine;
using Terrain = TDS.Maps.Terrain;

namespace TDS
{
    public class MonoMapFactory : MonoBehaviour, IFactory<IMap>
    {
        [SerializeField] private List<Bounds> _terrain;
        [SerializeField] private List<string> _names;
        [SerializeField] private List<Color> _colors;

        public IMap Create()
        {
            Map map = new Map();
            
            _terrain.ForEach(x => map.TerrainsCollection.Add(new Terrain("empty", new BoundsArea(x))));

            return map;
        }
    }
}