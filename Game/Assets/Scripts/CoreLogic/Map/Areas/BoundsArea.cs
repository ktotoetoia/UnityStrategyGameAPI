using UnityEngine;

namespace TDS.Maps
{
    public class BoundsArea : IArea
    {
        public Bounds Bounds { get; }
        public Vector3 Position => Bounds.center;
        
        public BoundsArea(Bounds bounds)
        {
            Bounds = bounds;
        }

        public bool Contains(Vector3 position)
        {
            return Bounds.Contains(position);
        }
    }
}