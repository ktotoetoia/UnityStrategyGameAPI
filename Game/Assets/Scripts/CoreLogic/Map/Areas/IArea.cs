using UnityEngine;

namespace TDS.Maps
{
    public interface IArea : IHavePosition
    {
        bool Contains(Vector3 position);
    }
}