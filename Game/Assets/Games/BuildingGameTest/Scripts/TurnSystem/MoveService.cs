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
        private Func<bool> _canUse;
        public bool CanUse => _canUse();
        
        private readonly MapPathfinder _pathfinder;
        private readonly ISelectionProvider _terrainSelector;
        private readonly ISelector _selector;
        
        public MoveService(Func<bool> canUse,MapPathfinder pathfinder, ISelectionProvider terrainSelector, ISelector selector)
        {
            _canUse = canUse;
            _pathfinder = pathfinder;
            _terrainSelector = terrainSelector;
            _selector = selector;
        }
        
        public void Move()
        {
            if (!CanUse)
            {
                throw new Exception("Can't use Move");
            }
            
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ITerrainArea targetTerrain = _terrainSelector.SelectAt<ITerrain>(clickPosition).First.TerrainArea;
            IEntity unit = _selector.GetSelection<IEntity>().First;

            if (!unit.TryGetComponent(out IActionDoer movementComponent) ||
                !unit.TryGetComponent(out IPlacedOnTerrain movementOnTerrain))
            {
                return;
            }
            
            IPath<ITerrain> path = _pathfinder.GetPath(movementOnTerrain.PlacedOn.Entity as ITerrain, targetTerrain.Entity as ITerrain, movementComponent.MaxActionPoints);
                
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