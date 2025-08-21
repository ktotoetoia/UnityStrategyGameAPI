using UnityEngine;

namespace TDS.Components
{
    public interface ITransformComponent : IComponent, IHavePosition
    {
        void SetPosition(Vector3 position);
    }
}