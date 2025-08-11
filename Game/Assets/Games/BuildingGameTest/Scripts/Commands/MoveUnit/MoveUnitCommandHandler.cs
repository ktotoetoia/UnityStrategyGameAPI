using TDS.Entities;
using TDS.Maps;
using TDS.Pathfinding;
using UnityEngine;

namespace BuildingsTestGame
{
    public class MoveUnitCommandHandler
    {
        public void Handle(MoveUnitCommand movement)
        {
            if (movement.Unit.TryGetComponent(out IMapMovementComponent movementComponent)&& movement.Unit.TryGetComponent(out IPlacedOnTerrain movementOnTerrain))
            {
                IPath<ITerrain> path = movement.Pathfinder.GetPath(movementOnTerrain.PlacedOn.Entity as ITerrain, movement.TargetTerrain.Entity as ITerrain, movementComponent.TotalMovementPoints);
                
                foreach (IPathSegment<ITerrain> segment in path.Segments)
                {
                    if (movementComponent.AvailableMovementPoints < segment.Cost)
                    {
                        break;
                    }

                    movementOnTerrain.PlacedOn = segment.To.Value.GetComponent<IGameTerrainComponent>();
                    movementComponent.AvailableMovementPoints -= segment.Cost;
                }
            }
        }
    }
}