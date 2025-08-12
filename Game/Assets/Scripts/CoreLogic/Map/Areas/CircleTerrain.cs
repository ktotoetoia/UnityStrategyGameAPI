using UnityEngine;

namespace TDS.Maps
{
    public class CircleTerrain : TerrainComponent, ITerrainArea
    {
        public float Radius { get; }
        public Vector3 Position { get; private set; }

        public CircleTerrain(Vector3 position, float radius)
        {
            Position = position;
            Radius = radius;
        }

        public bool Contains(Vector3 position)
        {
            return Vector3.Distance(Position, position) <= Radius;
        }
        
        public void SetPosition(Vector3 position)
        {
            Position = position;
        }
    }
}