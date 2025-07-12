using UnityEngine;

namespace TDS.Components
{
    public class TransformComponent : Component, ITransformComponent
    {
        public Vector3 Position { get; set; }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }
    }
}