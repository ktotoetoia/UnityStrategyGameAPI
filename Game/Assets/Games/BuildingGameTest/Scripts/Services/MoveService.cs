using System;
using TDS.Entities;
using TDS.Factions;
using TDS.Maps;
using TDS.Pathfinding;
using UnityEditor;
using UnityEngine;

namespace BuildingsTestGame
{
    public class MoveService : IGameService
    {
        private readonly Func<bool> _canUse;
        private readonly MapPathfinder _pathfinder;
        private readonly IFaction _faction;
        public bool CanUse => _canUse();
        
        public MoveService(Func<bool> canUse,MapPathfinder pathfinder,IFaction faction)
        {
            _faction = faction;
            _canUse = canUse;
            _pathfinder = pathfinder;
        }

        public void Move(IEntity unit,ITerrainArea targetTerrain)
        {
            if (!CanUse)
            {
                throw new Exception("Can't use MoveService");
            }

            if (!unit.TryGetComponent(out IFactionComponent factionComponent) || factionComponent .Faction != _faction)
            {
                Debug.LogWarning("can not move units with different faction");
                return;
            }
            
            if (!unit.TryGetComponent(out IActionDoer actionComponent) ||
                !unit.TryGetComponent(out IPlacedOnTerrain onTerrain))
            {
                return;
            }
            
            IPath<ITerrain> path = _pathfinder.GetPath(onTerrain.PlacedOn.Entity as ITerrain, targetTerrain.Entity as ITerrain, actionComponent.ActionPoints.Value);
            
            foreach (IPathSegment<ITerrain> segment in path.Segments)
            {
                if (actionComponent.ActionPoints.Value < segment.Cost)
                {
                    break;
                }

                onTerrain.MoveTo(segment.To.Value.GetComponent<IGameTerrainComponent>());
                actionComponent.ActionPoints.Value -= segment.Cost;
            }
        }
    }
}