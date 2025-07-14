using UnityEngine;

namespace TDS.Worlds
{
    public interface IArea : IHavePosition
    {
        bool Contains(Vector3 position);
    }
}