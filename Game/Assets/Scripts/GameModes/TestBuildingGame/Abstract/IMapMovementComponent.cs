using TDS.Components;

namespace BuildingsTestGame
{
    public interface IMapMovementComponent : IComponent
    {
        IGameTerrain Terrain { get; set; }
        float MovementPoints { get; set; }
    }
}