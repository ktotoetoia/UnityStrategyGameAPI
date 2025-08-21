using TDS.Components;
using UnityEngine;

namespace TDS.Maps
{
    public interface ITerrainArea : ITerrainComponent, ITransformComponent
    {
        bool Contains(Vector3 position);
    }
}