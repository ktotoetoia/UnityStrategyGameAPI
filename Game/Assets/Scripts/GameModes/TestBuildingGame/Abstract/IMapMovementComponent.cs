using TDS.Components;
using TDS.Maps;

namespace BuildingsTestGame
{
    public interface IMapMovementComponent : IComponent
    {
        IGameTerrain Terrain { get; set; }
        float MovementPoints { get; set; }
    }
}