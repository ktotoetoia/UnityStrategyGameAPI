using System.Collections.Generic;
using TDS.Commands;
using TDS.Entities;
using TDS.Handlers;
using TDS.Maps;
using TDS.Pathfinding;

namespace BuildingsTestGame
{
    public class MoveUnitCommandHandler : IConditionalHandler<ICommand>
    {
        public bool CanHandle(ICommand command)
        {
            return command is MoveUnitCommand movement &&
                   movement.Unit.TryGetComponent(out IMapMovementComponent movementComponent) &&
                   movement.Unit.TryGetComponent(out IMovementOnTerrain terrainComponent) ;
        }

        public void Handle(ICommand command)
        {
            if (command is MoveUnitCommand movement && movement.Unit.TryGetComponent(out IMapMovementComponent movementComponent)&& movement.Unit.TryGetComponent(out IMovementOnTerrain terrainComponent))
            {
                IPath<ITerrain> path = movement.Pathfinder.GetPath(terrainComponent.Terrain.Entity as ITerrain, movement.TargetTerrain.Entity as ITerrain, movementComponent.MovementPoints);
                float pointsLeft = movementComponent.MovementPoints;
                
                foreach (IPathSegment<ITerrain> segment in path.Segments)
                {
                    if (pointsLeft <= 0)
                    {
                        break;
                    }

                    segment.To.Value.GetComponent<IGameTerrainComponent>().Unit = movement.Unit;
                    pointsLeft -= 1;
                }
            }
        }
    }
}