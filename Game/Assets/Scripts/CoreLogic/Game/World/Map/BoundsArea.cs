using UnityEngine;

namespace TDS.Worlds
{
    public class BoundsArea : IArea
    {
        public BoundsArea(Bounds bounds)
        {
            Bounds = bounds;
        }

        public Bounds Bounds { get; }
        public Vector3 Position => Bounds.center;

        public bool Contains(Vector3 position)
        {
            return Bounds.Contains(position);
        }
    }
}