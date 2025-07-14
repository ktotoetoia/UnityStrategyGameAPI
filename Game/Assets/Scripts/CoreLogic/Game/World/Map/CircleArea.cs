using UnityEngine;

namespace TDS.Worlds
{
    public class CircleArea : IArea
    {
        public CircleArea(Vector3 position, float radius)
        {
            Position = position;
            Radius = radius;
        }

        public float Radius { get; }
        public Vector3 Position { get; }

        public bool Contains(Vector3 position)
        {
            return Vector3.Distance(Position, position) <= Radius;
        }
    }
}