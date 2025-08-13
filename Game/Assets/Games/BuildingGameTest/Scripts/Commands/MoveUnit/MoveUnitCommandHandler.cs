using TDS.Entities;
using TDS.Maps;
using TDS.Pathfinding;

namespace BuildingsTestGame
{
    public class MoveUnitCommandHandler
    {
        public void Handle(MoveUnitCommand movement)
        {
            if (movement.Unit.TryGetComponent(out IActionDoer movementComponent)&& movement.Unit.TryGetComponent(out IPlacedOnTerrain movementOnTerrain))
            {
                IPath<ITerrain> path = movement.Pathfinder.GetPath(movementOnTerrain.PlacedOn.Entity as ITerrain, movement.TargetTerrain.Entity as ITerrain, movementComponent.MaxActionPoints);
                
                foreach (IPathSegment<ITerrain> segment in path.Segments)
                {
                    if (movementComponent.AvailableActionPoints < segment.Cost)
                    {
                        break;
                    }

                    movementOnTerrain.PlacedOn = segment.To.Value.GetComponent<IGameTerrainComponent>();
                    movementComponent.AvailableActionPoints -= segment.Cost;
                }
            }
        }
    }
}