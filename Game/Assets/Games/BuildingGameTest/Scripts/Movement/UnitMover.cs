using TDS.Entities;
using TDS.Maps;
using TDS.Pathfinding;

namespace BuildingsTestGame
{
    public class UnitMover
    {
        public void Handle(IEntity unit, ITerrainArea targetTerrain, IMapPathfinder pathfinder)
        {
            if (!unit.TryGetComponent(out IActionDoer movementComponent) ||
                !unit.TryGetComponent(out IPlacedOnTerrain movementOnTerrain))
            {
                return;
            }
            
            IPath<ITerrain> path = pathfinder.GetPath(movementOnTerrain.PlacedOn.Entity as ITerrain, targetTerrain.Entity as ITerrain, movementComponent.MaxActionPoints);
                
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