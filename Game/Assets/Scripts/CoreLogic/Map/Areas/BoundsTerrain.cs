using UnityEngine;

namespace TDS.Maps
{
    public class BoundsTerrain : TerrainComponent, ITerrainArea
    {
        public Bounds Bounds { get; private set; }
        public Vector3 Position => Bounds.center;
        
        public BoundsTerrain(Bounds bounds)
        {
            Bounds = bounds;
        }
        
        public void SetPosition(Vector3 position)
        {
            Bounds = new Bounds(position, Bounds.size);
        }

        public bool Contains(Vector3 position)
        {
            return Bounds.Contains(position);
        }
    }
}