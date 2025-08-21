using System;
using TDS.Entities;
using TDS.Maps;
using TDS.Pathfinding;
using TDS.SelectionSystem;
using UnityEngine;

namespace BuildingsTestGame
{
    public class MoveService : IGameService
    {
        private readonly Func<bool> _canUse;
        private readonly MapPathfinder _pathfinder;
        
        public bool CanUse => _canUse();
        
        public MoveService(Func<bool> canUse,MapPathfinder pathfinder)
        {
            _canUse = canUse;
            _pathfinder = pathfinder;
        }

        public void Move(IEntity unit,ITerrainArea targetTerrain)
        {
            if (!unit.TryGetComponent(out IActionDoer actionComponent) ||
                !unit.TryGetComponent(out IPlacedOnTerrain onTerrain))
            {
                return;
            }
            
            IPath<ITerrain> path = _pathfinder.GetPath(onTerrain.PlacedOn.Entity as ITerrain, targetTerrain.Entity as ITerrain, actionComponent.MaxActionPoints);
            
            foreach (IPathSegment<ITerrain> segment in path.Segments)
            {
                if (actionComponent.AvailableActionPoints < segment.Cost)
                {
                    break;
                }

                onTerrain.MoveTo(segment.To.Value.GetComponent<IGameTerrainComponent>());
                actionComponent.AvailableActionPoints -= segment.Cost;
            }
        }
    }
}