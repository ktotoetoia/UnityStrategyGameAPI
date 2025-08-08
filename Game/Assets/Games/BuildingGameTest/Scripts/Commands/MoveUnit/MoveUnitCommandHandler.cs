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
                   movement.Unit.TryGetComponent(out ITerrainComponent terrainComponent) ;
        }

        public void Handle(ICommand command)
        {
            if (command is MoveUnitCommand movement && movement.Unit.TryGetComponent(out IMapMovementComponent movementComponent)&& movement.Unit.TryGetComponent(out ITerrainComponent terrainComponent))
            {
                IPath<ITerrain> path = movement.Pathfinder.GetPath(terrainComponent.Terrain,movement.TargetTerrain,movementComponent.MovementPoints);
                float pointsLeft = movementComponent.MovementPoints;
                
                foreach (IPathSegment<ITerrain> segment in path.Segments)
                {
                    if (pointsLeft <= 0)
                    {
                        break;
                    }

                    (segment.To.Value as IGameTerrain).Unit = movement.Unit;
                    pointsLeft -= 1;
                }
            }
        }
    }
}