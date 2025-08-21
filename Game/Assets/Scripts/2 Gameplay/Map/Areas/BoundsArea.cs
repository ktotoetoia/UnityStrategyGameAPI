using UnityEngine;

namespace TDS.Maps
{
    public class BoundsArea : TerrainComponent, ITerrainArea
    {
        public Bounds Bounds { get; private set; }
        public Vector3 Position => Bounds.center;
        
        public BoundsArea(Bounds bounds)
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